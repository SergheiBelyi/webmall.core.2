using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Service.Interfaces;
using Webmall.UI.ViewModel.Common;

namespace Webmall.UI.Service.Implementations
{
    public class UserRegistration : IUserRegistration
    {

        private readonly IUserRepository _userRepository;
        private readonly IPresentationRepository _presentationRepository;
        private readonly ICmsRepository _cmsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public UserRegistration(IUserRepository userRepository, IPresentationRepository presentationRepository, ICmsRepository cmsRepository,
            IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _presentationRepository = presentationRepository;
            _cmsRepository = cmsRepository;
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }

        public void InitializeRegistrationReferences(Controller context)
        {
            //
            var days = new List<SelectListItem>();
            var months = new List<SelectListItem>();
            var years = new List<SelectListItem>();
            var cInfo = new CultureInfo(UserPreferences.CurrentCulture);
            //
            for (int i = 1; i < 32; i++)
                days.Add(new SelectListItem { Text = i.ToString(CultureInfo.InvariantCulture), Value = i.ToString(CultureInfo.InvariantCulture), Selected = i == DateTime.Today.Day });
            for (int i = 1; i < 13; i++)
                months.Add(new SelectListItem { Text = cInfo.DateTimeFormat.MonthNames[i - 1], Value = i.ToString(CultureInfo.InvariantCulture), Selected = i == DateTime.Today.Month });
            for (int i = DateTime.Today.Year; i > DateTime.Today.Year - 101; i--)
                years.Add(new SelectListItem { Text = i.ToString(CultureInfo.InvariantCulture), Value = i.ToString(CultureInfo.InvariantCulture), Selected = i == DateTime.Today.Year });
            //
            context.ViewBag.Day = days.AsEnumerable();
            context.ViewBag.Month = months.AsEnumerable();
            context.ViewBag.Year = years.AsEnumerable();
            context.ViewBag.DaysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            context.ViewBag.Regions = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture, ConfigHelper.CountryCode).Select(i => new SelectListItem { Text = i.Value, Value = i.Id }).ToList();
            //context.ViewBag.Organizations = _referenceRepository.GetAvailableRetailOrganizations(UserPreferences.CurrentCulture, ConfigHelper.CountryCode);
        }

        public MessageViewModel RegisterNewUser(Controller context, UserRegistrationData user, string representationFlag)
        {
            MessageViewModel messageModel;
            user.Guid = Guid.NewGuid();
            user.RegistrationDate = DateTime.Now;
            if (user.IsJuridical) // Юридическое лицо
            {
                MailHelper.SendJuridicalRegistrationInfo(user);

                messageModel = new MessageViewModel
                {
                    Title = SecurityResources.ThanksForRegistration,
                    Message = MailHelper.FormatString(
                        _cmsRepository.GetMailMessageTemplate(MailMessages.MsgJuridicalRegistrationInfoMessage)
                            .Text, null),
                    ImageSrc = context.Url.Content("~/Content/images/key.jpg")
                };
            }
            else
            {
                user.Id = _userRepository.SaveUser(user, representationFlag != "true");
                var userData = _userRepository.GetUser(user.Login);

                var u = new UrlHelper(context.ControllerContext.RequestContext);
                string url = u.Action("ConfirmRegistration", "Security");
                //// ReSharper disable PossibleNullReferenceException
                // ReSharper disable once AssignNullToNotNullAttribute
                var uriBuilder = new UriBuilder(context.Request.Url.Scheme, context.Request.Url.Host, context.Request.Url.Port, url,
                    "?id=" + userData.Guid);
                MailHelper.SendPhisicalRegistrationInfo(userData);
                MailHelper.SendRegistrationConfirmation(user, uriBuilder.Uri.OriginalString);

                var reprResult = "";
                if (representationFlag == "true")
                {
                    foreach (var code in user.ClientCodes.Split(','))
                    {
                        var normCode = code.Trim();
                        if (!string.IsNullOrEmpty(normCode))
                        {
                            _presentationRepository.AddRepresentation(user.Id, normCode, false, 0xff);
                        }
                    }
                }
                else
                {
                    var code = _clientRepository.CreateClient(user);
                    var normCode = code?.Trim();
                    if (!string.IsNullOrEmpty(normCode))
                    {
                        _presentationRepository.AddRepresentation(user.Id, normCode, false, 0xff);
                    }
                    else
                    {
                        return new MessageViewModel
                        {
                            Title = SharedResources.Error,
                            ImageSrc = context.Url.Content("~/Content/images/key.jpg"),
                            Message = SharedResources.ClientCreationError
                        };
                    }
                }

                var mailMessage = _cmsRepository.GetMailMessageTemplate(MailMessages.MsgRegistrationComplete).Text;
                var message = mailMessage.Contains("@{URL}")
                    ? SecurityResources.YourAccountWaitsConfirmation
                    : MailHelper.FormatString(mailMessage,
                        new { Url = uriBuilder.Uri.OriginalString, user.Password });

                if (!string.IsNullOrEmpty(reprResult))
                    message += "<span style=\"color:red;\">" +
                               SecurityResources.RepresentationRequestErrorTitle
                               + "</span/>"
                               + reprResult;

                messageModel = new MessageViewModel
                {
                    Title = SecurityResources.ThanksForRegistration,
                    ImageSrc = context.Url.Content("~/Content/images/key.jpg"),
                    Message = message
                };
            }

            return messageModel;
        }

        public void Validate(Controller context, UserRegistrationData user)
        {
            if (!string.IsNullOrEmpty(user.Address.LocalityName))
            {
                var localities = _addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, null);
                var locality = localities.FirstOrDefault(i => i.Value != user.Address.LocalityName);
                if (locality == null)
                   context.ModelState.AddModelError("", SecurityResources.WrongLocality);
                else
                {
                    user.Address.LocalityId = locality.Id;
                }
            }
        }
    }
}