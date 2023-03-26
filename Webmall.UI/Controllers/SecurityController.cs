using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using ViewRes;
using Webmall.Model;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.References;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Models;
using Webmall.UI.Models.UserManagement;
using Webmall.UI.Service.Interfaces;
using Webmall.UI.ViewModel.Security;

namespace Webmall.UI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IPresentationRepository _presentationRepository;
        private readonly ICmsRepository _cmsRepository;
        private readonly IUserRegistration _userRegistration;
        private readonly IAddressRepository _addressRepository;

        public SecurityController(IUserRepository userRepository, IClientRepository clientRepository,
            ICartRepository cartRepository, IPresentationRepository presentationRepository, ICmsRepository cmsRepository, 
            IUserRegistration userRegistration, IAddressRepository addressRepository)
        {
            _presentationRepository = presentationRepository;
            _cmsRepository = cmsRepository;
            _userRegistration = userRegistration;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public ActionResult LogOn(string returnUrl)
        {
            if (SessionHelper.CurrentUser != null)
                return RedirectToAction("Index", "Home");

            var newModel = new LogOnModel
            {
                ReturnUrl = returnUrl,
                RememberMe = ConfigHelper.IsDefaultRememberMe
            };

            return View(newModel);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl, string token, string viewName = null)
        {
            bool isSocialNetworkAuthorized = false;
            Dictionary<string, string> jsonObj = null;
            if (token != null)
            {
                var str = PhpHelper.file_get_contents("http://ulogin.ru/token.php?token=" + token + "&host=" + Request.Headers["Host"]);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                jsonObj = ser.Deserialize<Dictionary<string, string>>(str); //JSON decoded

                model.UserName = jsonObj["email"];
                model.Pass = token;
                isSocialNetworkAuthorized = true;

                //Console.Write(JSONObj["foo"]);

                //$user = json_decode($s, true);
                //$user['network'] - соц. сеть, через которую авторизовался пользователь
                //$user['identity'] - уникальная строка определяющая конкретного пользователя соц. сети
                //$user['first_name'] - имя пользователя
                //$user['last_name'] - фамилия пользователя
            }
            else if (!ModelState.IsValid)
            {
                //ViewBag.Organizations = _referenceRepository.GetAvailableRetailOrganizations(UserPreferences.CurrentCulture, ConfigHelper.CountryCode);
                //ViewBag.Regions = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture, ConfigHelper.CountryCode).Select(i => new SelectListItem { Text = i.Value, Value = i.Id }).ToList();

                ModelState.AddModelError(string.Empty, SecurityResources.BadPasswordOrLogin);
                return View(model);
            }

            var passwordHash = _userRepository.HashPassword(model.Pass);

            string ip = Request.ServerVariables["REMOTE_ADDR"];

            var user = _userRepository.Authentication(model.UserName, passwordHash, ip, isSocialNetworkAuthorized);

            if (user == null)
            {
                //ViewBag.Organizations = _referenceRepository.GetAvailableRetailOrganizations(UserPreferences.CurrentCulture, ConfigHelper.CountryCode);
                //ViewBag.Regions = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture, ConfigHelper.CountryCode).Select(i => new SelectListItem { Text = i.Value, Value = i.Id }).ToList();

                if (!isSocialNetworkAuthorized)
                {
                    ModelState.AddModelError(string.Empty, SecurityResources.BadPasswordOrLogin);
                    return View("Logon", model);
                }

                // Создаем пользователя по авторизации через соц.сеть
                user = new User
                {
                    FirstName = jsonObj["first_name"],
                    LastName = jsonObj["last_name"],
                    RegistrationDate = DateTime.Now,
                    Login = model.UserName,
                    Password = model.Pass,
                    SubscribeForPromotions = true,
                    Guid = Guid.NewGuid(),
                    PhoneMobile = (jsonObj.ContainsKey("phone") ? jsonObj["phone"] ?? "" : "").Replace("-", "")
                };
                ModelState.Clear();
                return View(viewName ?? "LogOn", user);
            }

            // Проверка блокировок
            string message = null;
            if (user.IsBlocked) message = SecurityResources.YourAccountIsLocked;
            else if (!user.IsAccepted) message = SecurityResources.YourAccountWaitsConfirmation;
            else if (user.Status == (long)UserStatuses.NoClients) message = SecurityResources.NoClientsRegistered;

            // Если есть сообщение об ошибке
            if (message != null)
            {
                ModelState.AddModelError(string.Empty, message);
                return View("Logon", model);
            }

            user = _userRepository.GetUser(user.Login);

            //user.CurrentPresenter.Client = _clientRepository.GetFullClientInfo(user.CurrentPresenter.ClientId);
            //if (user.CurrentPresenter.Client == null)
            //{
            //    foreach (var presenter in user.ActivePresenters.ToArray())
            //    {
            //        presenter.Client = _clientRepository.GetFullClientInfo(presenter.ClientId);
            //        if (presenter.Client != null)
            //        {
            //            user.CurrentPresenter = presenter;
            //            presenter.Client.IsLoaded = true;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    user.CurrentPresenter.Client.IsLoaded = true;
            //}
            

            model.AllowBackend = (user.Roles & (long)UserRoles.ContentManager) > 0;
            var serializedUser = model.ToJson();

            var expirationTime = model.RememberMe ? DateTime.Today.AddMonths(12) : DateTime.Now.AddHours(ConfigHelper.AuthTicketExpiration);

            var ticket = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, expirationTime, true, serializedUser);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var isSsl = Request.IsSecureConnection; // if we are running in SSL mode then make the cookie secure only

            var cookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true, // always set this to true!
                Secure = isSsl,
                Expires = expirationTime
            };

            Response.Cookies.Set(cookie);

            //FormsAuthentication.SetAuthCookie(user.Login, model.RememberMe);
            SessionHelper.ClearSession();
            //_referenceRepository.ClearValuteCache(user, UserPreferences.CurrentCulture);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            SessionHelper.ClearSession();
            SessionHelper.InvalidateCurrentUser(SessionHelper.CurrentUser.Login);
            return RedirectToAction("Index", "Home");
        }

        public RedirectResult ChangeCulture(string culture, string redirectUrl)
        {
            if (!string.IsNullOrEmpty(culture))
                UserPreferences.CurrentCulture = culture;
            return Redirect(!string.IsNullOrEmpty(redirectUrl) ? redirectUrl : "\\");
        }

        public JsonResult IsLoginAvailable(string login)
        {
            var result = new JsonResult { Data = _userRepository.IsUserLoginFree(login), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        public JsonResult IsNewLoginAvailable(string newLogin)
        {
            bool isAvailable = _userRepository.IsUserLoginFree(newLogin);
            var result = new JsonResult { Data = isAvailable, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            if (!isAvailable && !string.IsNullOrEmpty(newLogin)) { result.Data = SecurityResources.EmailAlreadyRegistered; }
            return result;
        }

        public JsonResult CheckPhone(string phoneMobile)
        {
            var message = _userRepository.CheckPhone(ConfigHelper.PhonePrefix + phoneMobile, UserPreferences.CurrentCulture);
            var result = new JsonResult { Data = string.IsNullOrEmpty(message) ? "true" : message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Registration()
        {
            _userRegistration.InitializeRegistrationReferences(this);
            return View(new UserRegistrationData());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RecaptchaValidation]
        public ActionResult Registration(UserRegistrationData user, string password2, string agreementFlag, string representationFlag)
        {
            var isLoginAvailable = IsLoginAvailable(user.Login);
            if (!bool.Parse(isLoginAvailable.Data.ToString()))
            {
                ModelState.AddModelError("", SecurityResources.EmailAlreadyRegistered);
            }
            var captchaValid = (bool)RouteData.Values["captchaValid"] || Request.IsLocal || ConfigHelper.SkipCaptchaCheck;
            if (captchaValid != true)
            {
                ModelState.AddModelError("", SecurityResources.WrongRecaptchaSimpleMessage);
            }
            else
            {
                if (agreementFlag?.ToLowerInvariant() != "true")
                {
                    ModelState.AddModelError("", SecurityResources.WrongAgreementFlag);
                }
                else if (representationFlag == "true"
                    && (string.IsNullOrWhiteSpace(user.ClientCodes) || !user.ClientCodes.Split(',').Any())
                    )
                {
                    ModelState.AddModelError("", SecurityResources.WrongClientCodes);
                }
                if ((string.IsNullOrEmpty(user.Password)) || (user.Password != password2))
                {
                    ModelState.AddModelError("", SecurityResources.WrongPassword);
                }

                _userRegistration.Validate(this, user);
            }
            if (ModelState.IsValid)
            {
                var messageModel = _userRegistration.RegisterNewUser(this, user, representationFlag);
                return View("MessagePage", messageModel);
            }

            _userRegistration.InitializeRegistrationReferences(this);
            return View(user);
        }

        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult InternalRegistration()
        {
            var user = new UserRegistrationData();
            _userRegistration.InitializeRegistrationReferences(this);
            return View(user);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult InternalRegistration(UserRegistrationData user, string password2, string password3)
        {

            _userRegistration.InitializeRegistrationReferences(this);

            if ((string.IsNullOrEmpty(user.Password)) || (user.Password != password2 && user.Password != password3))
                ModelState.AddModelError("", SecurityResources.WrongPassword);

            if (!_userRepository.IsUserLoginFree(user.Login))
                ModelState.AddModelError("Login", SecurityResources.EmailAlreadyRegistered);


            if (ModelState.IsValid)
            {
                //var u = new UrlHelper(ControllerContext.RequestContext);
                user.Guid = Guid.NewGuid();

                user.RegistrationDate = DateTime.Now;
                user.Id = _userRepository.SaveUser(user, false);
                _userRepository.Confirmation(user.Guid.ToString());
                string reprResult = "";
                if (!string.IsNullOrEmpty(user.ClientCodes))
                {
                    foreach (var code in user.ClientCodes.Split(','))
                    {
                        var normCode = code.Trim();
                        if (!string.IsNullOrEmpty(normCode))
                        {
                            _presentationRepository.AddRepresentation(user.Id, normCode, true, 0xff);
                        }
                    }
                }
                TempData["Message"] = SharedResources.RegistrationSuccessful;
                if (!string.IsNullOrEmpty(reprResult))
                    TempData["Message"] = TempData["Message"] +
                        "<span style=\"color:red;\">" +
                        SecurityResources.RepresentationRequestErrorTitle
                        + "</span/>"
                        + reprResult;
                TempData["Title"] = SecurityResources.ThanksForRegistration;
                TempData["MsgImage"] = Url.Content("~/Content/images/key.jpg");
                return RedirectToAction("Show", "Message");
            }

            return View("InternalRegistration", user);
        }


        [Authorize]
        public ActionResult EditPersonalData()
        {
            _userRegistration.InitializeRegistrationReferences(this);
            var userData = SessionHelper.CurrentUser; // _userRepository.GetUser(SessionHelper.CurrentUser.Login);
            return View(userData);
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditPersonalData(User user, string oldPassword, string password2)
        {
            if (SessionHelper.CurrentUser == null)
            {
                return RedirectToAction("EditPersonalData");
            }
            var dbuser = _userRepository.GetUser(user.Login);
            var changePassword = false;
            if (!string.IsNullOrWhiteSpace(oldPassword) || !string.IsNullOrEmpty(user.Password) || !string.IsNullOrEmpty(password2))
            {
                var passwordHash = _userRepository.HashPassword(oldPassword);
                string ip = Request.ServerVariables["REMOTE_ADDR"];
                var oldUser = _userRepository.Authentication(SessionHelper.CurrentUser.Login, passwordHash, ip, false);
                if (oldUser == null)
                {
                    ModelState.AddModelError("", SecurityResources.WrongOldPassword);
                }
                if (string.IsNullOrEmpty(user.Password) || user.Password != password2) 
                    ModelState.AddModelError("", SecurityResources.WrongPassword);
                changePassword = true;
            }

            if (ModelState.IsValid)
            {
                dbuser.Password = changePassword ? user.Password : "";
                if (user.FirstName != null)
                    dbuser.FirstName = user.FirstName;
                if (user.LastName != null)
                    dbuser.LastName = user.LastName;
                if (user.PhoneHome != null)
                    dbuser.PhoneHome = user.PhoneHome;
                if (user.PhoneMobile != null)
                    dbuser.PhoneMobile = user.PhoneMobile;
                //dbuser.Address.Zip = user.Address.Zip;
                dbuser.Configuration.SendOrderResume = user.Configuration.SendOrderResume;
                dbuser.Configuration.SubscribeForPromotions = user.Configuration.SubscribeForPromotions;
                dbuser.Configuration.ShowRetailPrice = user.Configuration.ShowRetailPrice;
                _userRepository.SaveUser(dbuser, true);
                SessionHelper.ClearSession();
                SessionHelper.InvalidateUser(user.Login, true);
            }
            _userRegistration.InitializeRegistrationReferences(this);
            return View(user);
        }

        public ActionResult ConfirmRegistration(string id)
        {
            var u = new UrlHelper(ControllerContext.RequestContext);
            var result = _userRepository.Confirmation(id);
            if (result)
            {
                // ReSharper disable PossibleNullReferenceException
                string logonUrl = u.Action("LogOn", "Security", Request.Url.Scheme);
                TempData["Title"] = SecurityResources.RegistrationConfirmation;
                TempData["Message"] = MailHelper.FormatString(_cmsRepository.GetMailMessageTemplate(MailMessages.MsgAcceptRegistrationSucces).Text, new { SiteURL = u.Action("Index", "Home", Request.Url.Scheme), URL = logonUrl });
                TempData["MsgImage"] = Url.Content("~/Content/images/key.jpg");
                return RedirectToAction("Show", "Message");
            }
            string registrationUrl = u.Action("Registration", "Security", Request.Url.Scheme);
            TempData["Title"] = SharedResources.Error;
            TempData["Message"] = MailHelper.FormatString(_cmsRepository.GetMailMessageTemplate(MailMessages.MsgAcceptRegistrationFail).Text, new { URL = registrationUrl });
            TempData["MsgImage"] = Url.Content("~/Content/images/error.jpg");
            return RedirectToAction("Show", "Message");
            // ReSharper restore PossibleNullReferenceException
        }

        public ActionResult BlockSendingOrderResume(string id1, string id2)
        {
            var result = _userRepository.BlockSendingOrderResume(id1, id2);
            if (result)
            {
                TempData["Message"] = string.Format(SharedResources.BlockingSendOrderResumeSuccessMessage, SharedResources.Profile);
                return RedirectToAction("Show", "Message");
            }
            TempData["Message"] = string.Format(SharedResources.BlockingSendOrderResumeErrorMessage, SharedResources.Profile);
            return RedirectToAction("Show", "Message");
        }

        private PasswordRecoveryViewModel PreparePasswordRecoveryViewModel(string login = null)
        {
            return new PasswordRecoveryViewModel
            {
                Login = login,
                Text = _cmsRepository.GetIncorporatingText("password_recovery_text")?.Text,
                Label = _cmsRepository.GetIncorporatingText("password_recovery_label")?.Text
            };
        }

        public ActionResult PasswordRecovery()
        {
            return View(PreparePasswordRecoveryViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RecaptchaValidation]
        public ActionResult PasswordRecovery(string login)
        {
            var captchaValid = (bool)RouteData.Values["captchaValid"] || Request.IsLocal || ConfigHelper.SkipCaptchaCheck;
            if (!captchaValid)
            {
                ModelState.AddModelError("", SecurityResources.WrongRecaptchaSimpleMessage);
                return View();
            }

            login = (login ?? "").Trim();
            var user = _userRepository.GetUser(login);

            if (user == null) // User not found
            {
                ModelState.AddModelError("", SecurityResources.UserNotFound);
                return View(PreparePasswordRecoveryViewModel(login));
            }

            var pin = PinGenerateAndSend(user.Login, user.Email);

            return View("PasswordRecoveryPinCheck", pin);
        }

        private PinCode PinGenerateAndSend(string login, string email)
        {
            var pin = new PinCode {Owner = login, Code = PinGenerator.Generate(), ValidTo = DateTime.Now.AddMinutes(10)};

            var mail = MailHelper.Msg2Mail(MailMessages.MsgPasswordRecovery, new {code = pin.Code});
            Session["Pin"] = pin;

            MailHelper.SendMailMessage(email, mail);
            return pin;
        }

        public ActionResult ChangePassword(string pinCode, string password, string password2)
        {
            PinCode pin = Session["Pin"] as PinCode;
            if (pin == null)
            {
                return RedirectToAction("PasswordRecovery");
            }

            if (pin.ValidTo <= DateTime.Now)
            {
                return RedirectToAction("PasswordRecovery");
            }

            if (pin.Code != pinCode)
            {
                pin.AttemptsRemain--;
                if (pin.AttemptsRemain == 0)
                    return RedirectToAction("PasswordRecovery");

                ModelState.AddModelError("", SecurityResources.WrongPin);
                return View("PasswordRecoveryPinCheck", pin);
            }

            if (password != password2)
            {
                ModelState.AddModelError("", SecurityResources.WrongPassword);
                return View("PasswordRecoveryPinCheck", pin);
            }

            _userRepository.UpdateUserPassword(pin.Owner, password);
            return RedirectToAction("LogOn");
        }

        public ActionResult ResendPin()
        {
            PinCode pin = Session["Pin"] as PinCode;
            if (pin == null)
            {
                return RedirectToAction("PasswordRecovery");
            }
            pin = PinGenerateAndSend(pin.Owner, pin.Owner);
            return View("PasswordRecoveryPinCheck", pin);
        }

        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult UsersManagement(UserFilter filter, GridViewOptions options)
        {
            if (string.IsNullOrEmpty(options.SortColumn))
            {
                options.SortColumn = "FullName";
            }
            var model = new UserListModel
            {
                Users = _userRepository.GetUsers(filter).AsGridView(ControllerContext, options, null, "FullName"),
                Filter = filter
            };
            return View(model);
        }


        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult RemoveUser(string userLogin, string returnUrl)
        {
            var user = _userRepository.GetUser(userLogin);
            _userRepository.RemoveUser(user);
            return Redirect(returnUrl);
        }

        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult ConfirmUser(string guid, string returnUrl)
        {
            _userRepository.Confirmation(guid);
            return Redirect(returnUrl);
        }

        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult InvalidateUser(string userLogin, string returnUrl)
        {
            SessionHelper.InvalidateUser(userLogin);
            return Redirect(returnUrl);
        }

        [Authorize]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult EditUserData(string userLogin, string returnUrl)
        {
            ViewBag.ReturnURL = returnUrl;
            var user = _userRepository.GetUser(userLogin);
            return View(user);
        }

        [Authorize]
        [HttpPost]
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult EditUserData(User user, bool isBlocked, long[] selectedRoles, string returnUrl, string password, string password2, string newLogin)
        {
            var dbuser = _userRepository.GetUser(user.Login);
            bool changePassword = !string.IsNullOrEmpty(user.Password) && user.Password == password2;
            if (ModelState.IsValid)
            {
                dbuser.Password = changePassword ? user.Password : null;
                if (!string.IsNullOrEmpty(newLogin))
                {
                    if (_userRepository.IsUserLoginFree(newLogin))
                    {
                        dbuser.Login = newLogin;
                    }
                }
                dbuser.Status = user.Status.SetFlag((long)UserStatuses.Blocked, isBlocked);

                dbuser.Roles = 0;
                if (selectedRoles != null)
                    foreach (var role in selectedRoles) dbuser.Roles = dbuser.Roles.SetFlag(role, true);
                dbuser.IsVinSearchDefaultLimit = user.IsVinSearchDefaultLimit;
                dbuser.IsVinSearchUnlimited = user.IsVinSearchUnlimited;
                dbuser.VinSearchLimitCounter = user.VinSearchLimitCounter;
                dbuser.VinSearchLimitDate = user.VinSearchLimitDate;
                _userRepository.SaveUser(dbuser, true);

                if (dbuser.Id == SessionHelper.CurrentUser.Id)
                    SessionHelper.CurrentUser.Roles = dbuser.Roles;

                if (changePassword)
                    SessionHelper.InvalidateUser(user.Login, true);
            }
            return Redirect(returnUrl);
        }

        [Authorize]
        public ActionResult ChangeCurrentClient(string id, string returnUrl)
        {
            var user = SessionHelper.CurrentUser;

            var presenter = user.Presenters?.FirstOrDefault(i => i.ClientId == id);
            var client = presenter?.Client;

            if (client == null)
                return Redirect(returnUrl);

            if (!client.IsLoaded)
            {
                client = _clientRepository.GetFullClientInfo(user.CurrentPresenter.ClientId);
                if (client != null)
                {
                    client.IsLoaded = true;
                }
                presenter.Client = client;
            }

            if (client != null)
            {
                user.CurrentPresenter = presenter;
                _userRepository.ChangeCurrentClient(user);
                client.Breefing.Clear();
                SessionHelper.Cart = _cartRepository.GetCart(UserPreferences.CurrentCulture, user);
            }

            return Redirect(returnUrl);
        }

        //        public ActionResult ChangeCurrentValute(string id, string returnUrl)
        //        {
        //            if (SessionHelper.CurrentUser != null)
        //                SessionHelper.CurrentUser.ValuteId = id;
        //            return Redirect(returnUrl);
        //        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RecaptchaValidation]
        public ActionResult OnlineHelp(string userName, string userContacts, string userMessage, string redirectUrl, string img)
        {
            var captchaValid = (bool)RouteData.Values["captchaValid"] || Request.IsLocal;
            if (captchaValid || SessionHelper.CurrentUser != null)
            {
                byte[] image = Convert.FromBase64String(img);
                const string fileName = "screenshot.png"; // ConfigHelper.AccessLogPath + DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss") + ".png";

                //var file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                //// Writes a block of bytes to this stream using data from
                //// a byte array.
                //file.Write(image, 0, image.Length);

                //// close file stream
                //file.Close();
                var stream = new MemoryStream(image);

                MailHelper.SendMessageToManager(userContacts ?? SessionHelper.CurrentUser.Email, userName ?? SessionHelper.CurrentUser.FullName, userMessage, stream, fileName);
                TempData["Message"] = SharedResources.YourMessageSuccessfullySent;
                return RedirectToAction("Show", "Message");

                //return Redirect(redirectUrl);
            }
            TempData["Message"] = SecurityResources.WrongCAPTCHA;
            return RedirectToAction("Show", "Message");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [RecaptchaValidation]
        public ActionResult BotDetectedClearing()
        {
            var captchaValid = (bool)RouteData.Values["captchaValid"] || Request.IsLocal;
            if (captchaValid || Request.Url?.Host == "localhost")
            {
                MvcApplication.AccessStatistics.ClearCurrentUSerBlock();
                System.Web.HttpContext.Current.Session["IsHuman"] = true;

            }
            return RedirectToAction("Index", "Home");
        }

        // ReSharper disable once InconsistentNaming
        public JsonResult UILocalities(string regionId, string term)
        {
            var result = SimpleReferenceItem.Convert(_addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, regionId)
                    .Where(s => s.Value.ToLower().StartsWith(term.ToLower())).Take(50), false).OrderBy(i => i.Text)
                    .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult CheckLocality(Address address)
        {
            var localities = _addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, null);

            var result = new JsonResult { Data = localities.Any(i => i.Value == address.LocalityName) 
                ? "true" 
                : SecurityResources.WrongLocality, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

    }
}
