using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.ViewModel.Client;
using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly IPresentationRepository _presentationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICmsRepository _cmsRepository;
        private readonly IUserRepository _userRepository;

        public ClientsController(IPresentationRepository presentationRepository,
            IClientRepository clientRepository, ICmsRepository cmsRepository, IUserRepository userRepository)
        {
            _clientRepository = clientRepository;
            _cmsRepository = cmsRepository;
            _userRepository = userRepository;
            _presentationRepository = presentationRepository;
        }

        public ActionResult Index()
        {

            var model = new ClientViewModel
            {
                Client = SessionHelper.CurrentClient,
                CurrentClientPresenter = SessionHelper.CurrentUser.CurrentPresenter,
                //Warehouses = _referenceRepository.GetWarehouses(SessionHelper.CurrentClientId, UserPreferences.CurrentCulture)
                //    .Select(i => new SelectListItem {Text = i.Value, Value = i.Id.ToString()})
            };
            //if (model.Client != null)
            //    model.Client.Client.Contracts = _clientRepository.GetClientContracts(model.Client.Client.Id, UserPreferences.CurrentCulture);
            //InitializeRegistrationReferences();
            var clientId = model.Client?.Id;

            var user = SessionHelper.CurrentUser;
            if (user.CurrentPresenter.IsKeyRepresentative || user.Roles.IsFlagSet(UserRoles.RepresentativeManager))
                model.AllClientPresenters = _presentationRepository.GetPresentationsList(clientId);
            else
                model.AllClientPresenters = new List<ClientPresenter>();
            return View(model);
        }

        //public PartialViewResult DeliveryAddresses()
        //{
        //    var client = SessionHelper.CurrentClient;
        //    //var clientId = SessionHelper.CurrentClientId;
        //    var model = new DeliveryAddressesModel
        //    {
        //        Client = client,
        //        Addresses = _addressRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, client?.Id, UserPreferences.CurrentCulture),
        //        AllowEdit = true,  //SessionHelper.IsGross,
        //        //EditCallback = editCallback,
        //        //MaxAddresses = _cmsRepository.GetDeliveryConfig().MaxAdressesCount,
        //    };

        //    return PartialView("DeliveryAddresses", model);
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult SaveContact (Contact contact)
        {
            if (SessionHelper.CurrentClientId != null)
            {
                contact.Id = _clientRepository.SaveClientContact(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, contact);
            }

            return PartialView("_ContactCard", contact);
        }

        public ActionResult DeleteContact(string contactId)
        {
            _clientRepository.RemoveClientContact(SessionHelper.CurrentUser, contactId, SessionHelper.CurrentClientId);
            return null;
        }

        //[AllowAnonymous]
        //public JsonResult GetRegions(string term = "")
        //{
        //    var result = SimpleReferenceItem.Convert(_addressRepository.GetRegions(null, UserPreferences.CurrentCulture)
        //            //.Where(s => s.Name.ToLower().StartsWith(term.ToLower()))
        //            , false)
        //        .OrderBy(i => i.Text)
        //        .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //// ReSharper disable once InconsistentNaming
        //[AllowAnonymous]
        //public JsonResult GetLocalities(string regionId, string term = "")
        //{
        //    var result = SimpleReferenceItem.Convert(_addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, regionId)
        //            .Where(s => string.IsNullOrEmpty(term) || s.Value.ToLower().StartsWith(term.ToLower())), false).OrderBy(i => i.Text)
        //        .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //[AllowAnonymous]
        //// ReSharper disable once InconsistentNaming
        //public JsonResult UIAddresses(string term, int? cityId)
        //{
        //    var result = _addressRepository.GetStreets(UserPreferences.CurrentCulture, cityId).Where(s => s.Value?.ToLower().Contains(term.ToLower()) == true).Take(50).OrderBy(i => i.Value)
        //        .Select(i => new { id = i.Id, value = i.Value, label = i.Value });

        //    //var result = new List <object>
        //    //{
        //    //    new { id = 1, value = "1", label = "1", HaveDistricts = true },
        //    //    new { id = 2, value = "2", label = "2", HaveDistricts = true },
        //    //    new { id = 3, value = "3", label = "3", HaveDistricts = false },
        //    //    new { id = 4, value = "4", label = "4", HaveDistricts = false },
        //    //};
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //[AllowAnonymous]
        //public JsonResult Localities(string q, int limit)
        //{
        //    var result = SimpleReferenceItem.Convert(_addressRepository.GetLocalities(null, null, UserPreferences.CurrentCulture).Where(s => s.Value.ToLower().StartsWith(q.ToLower())).Take(limit), false).OrderBy(i => i.Text);
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //[AllowAnonymous]
        //public JsonResult Addresses(string q, int limit, int? cityId)
        //{
        //    //var result = SimpleReference.Convert(ReferenceRepository.GetStreets(UserPreferences.CurrentCulture), true).Where(s => s.Text.ToLower().Contains(q.ToLower())).Take(limit).OrderBy(i => i.Text);
        //    var result = _addressRepository.GetStreets(UserPreferences.CurrentCulture, cityId).Where(s => s.Value.ToLower().Contains(q.ToLower())).Take(limit).OrderBy(i => i.Value);
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public JsonResult Districts(string q, int limit, int? cityId, int? streetId)
        //{
        //    var result = SimpleReferenceItem.Convert(_referenceRepository.GetCityDistricts(UserPreferences.CurrentCulture, cityId, streetId), false).Where(s => s.Text.ToLower().Contains(q.ToLower())).Take(limit).OrderBy(i => i.Text);
        //    //var result = new List<SimpleReference>
        //    //{
        //    //    new SimpleReference { Id = 1, Name = "1"},
        //    //    new SimpleReference { Id = 2, Name = "2"},
        //    //    new SimpleReference { Id = 3, Name = "3"},
        //    //    new SimpleReference { Id = 4, Name = "4"},
        //    //};
        //    return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public PartialViewResult Delete(string id)
        //{
        //    _addressRepository.RemoveDeliveryAddress(id, SessionHelper.CurrentClientId);
        //    return DeliveryAddresses();
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult SaveAddressNew(DeliveryAddress address)
        //{
        //    if (SessionHelper.CurrentClientId != null)
        //        _addressRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, address);
        //    return RedirectToAction("Index");
        //}

        //[AcceptVerbs(HttpVerbs.Post)]
        //public PartialViewResult SaveAddress(DeliveryAddress address)
        //{
        //    if (SessionHelper.CurrentClientId != null)
        //        _addressRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, address);
        //    return DeliveryAddresses();
        //}

        //public JsonResult SetDefaultDeliveryAddress(string clientId, string addressId)
        //{
        //    if (SessionHelper.CurrentClientId != null)
        //        _addressRepository.SetDefaultDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, addressId);
        //    return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public JsonResult ChangeDefaultWarehouse(string clientId, string warehouseId)
        {
            _clientRepository.ChangeDefaultWarehouse(SessionHelper.CurrentUser, clientId, warehouseId);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //private void InitializeRegistrationReferences()
        //{
        //    //           ViewData["Localities"] = SimpleReference.Convert(ReferenceRepository.GetLocalities(UserPreferences.CurrentCulture, -1), false);
        //    //           ViewData["Streets"] = SimpleReference.Convert(ReferenceRepository.GetStreets(UserPreferences.CurrentCulture), false);
        //}

        [Authorize]
        [HttpPost]
        public ActionResult AddRepresentation(string clientCode, int? userId)
        {
            string message = null;
            if (string.IsNullOrWhiteSpace(clientCode))
                message = SharedResources.ClientCodeIsEmpty;

            Client client = null;
            if (message is null)
            {
                client = _clientRepository.GetFullClientInfo(clientCode);
                if (client == null)
                    message = string.Format(SharedResources.ClientNotFound, clientCode);
            }

            if (message is null)
            {
                var user = SessionHelper.CurrentUser;
                if (!user.Roles.IsFlagSet(UserRoles.RepresentativeManager) || userId == null)
                    userId = user.Id;
                var presentations = _presentationRepository.GetPresentationsList(clientCode);
                if (presentations.Exists(i => i.UserId == userId))
                {
                    message = SharedResources.RepresentationAlreadyCreated + " " + client.Name;
                }
                else
                {
                    var role = 0;
                    if (!presentations.Exists(i => i.IsKeyRepresentative))
                        role = 0xff;
                    _presentationRepository.AddRepresentation(userId.Value, clientCode, false, role);

                    MailHelper.SendNewRepresentationNotification(user, clientCode, client.Name,
                        role == 0xff
                            ? _userRepository.GetUsers(new UserFilter {IsRepresentativeManager = true}) // Нет ключевых сотрудников - сообщение менеджерам
                            : presentations.Where(i => i.IsKeyRepresentative).Select(i => i.User)); // Есть ключевые - сообщение им
                    return null;
                }
            }

            return View("MessagePage", 
                new MessageViewModel(SharedResources.RequestError, 
                                     MailHelper.FormatString(_cmsRepository.GetMailMessageTemplate(MailMessages.MsgRepresentationRequestError).Text, new { message })));
        }

        /// <summary>
        /// Удаляет представительство
        /// </summary>
        /// <param name="id">Код представительства</param>
        /// <param name="clientId">Код клиента</param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeleteRepresentation(int id, string clientId)
        {
            var presenter = _presentationRepository.GetClientPresenter(id);
            var canDelete = presenter.UserId == SessionHelper.CurrentUser.Id && !presenter.IsAccepted;
            if (IsUserRepresentationManager(id, presenter) || canDelete)
            {
                _presentationRepository.RemoveRepresentation(id);

                //TODO: нужно ли уведомление об удалении представительства
                //var presentation = _presentationRepository.RemoveRepresentation(id);
                //var user = presentation.User;
                //var clientInfo = _clientRepository.GetFullClientInfo(presentation.ClientId);

                //MailHelper.SendRepresentationRequestRejectNotification(user, clientInfo.Code, clientInfo.Name, new[] { user });
            }

            return RedirectToAction("Index", new { clientId });
        }

        [Authorize]
        public ActionResult Approve(int id)
        {
            if (IsUserRepresentationManager(id))
            {
                var presentation = _presentationRepository.ApproveRepresentation(id);

                if (presentation != null)
                {
                    var user = presentation.User;
                    var clientInfo = _clientRepository.GetFullClientInfo(presentation.ClientId);

                    MailHelper.SendRepresentationConfirmationNotification(user, clientInfo.Code, clientInfo.Name,
                        new[] { user });
                }
            }

            return RedirectToAction("Index");
        }

        private bool IsUserRepresentationManager(int id, ClientPresenter presenter = null)
        {
            var clientId = (presenter ?? _presentationRepository.GetClientPresenter(id))?.ClientId;
            return SessionHelper.CurrentUser.Roles.IsFlagSet((int)UserRoles.RepresentativeManager)
                || SessionHelper.CurrentUser.Presenters.Count(i => i.ClientId == clientId && i.IsKeyRepresentative) != 0;
        }

        public JsonResult ChangeRepresentationRole(string id, bool state)
        {
            var s = id.Split('_');
            if (IsUserRepresentationManager(int.Parse(s[1])))
            {
                int presentationId = int.Parse(s[1]);
                long newRole = _presentationRepository.ChangeRepresentationRole(presentationId, s[0], state);
                if (SessionHelper.CurrentUser.CurrentPresenter.Id == presentationId)
                    SessionHelper.CurrentUser.CurrentPresenter.Roles = newRole;
            }
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize]
        public ActionResult ChangeCurrentWarehouse(string id, string returnUrl)
        {
            SessionHelper.CurrentClient.CurrentWarehouseId = id;
            return Redirect(returnUrl);
        }
    }
}
