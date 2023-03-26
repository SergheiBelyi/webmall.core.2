using System.Linq;
using System.Web.Mvc;
using Webmall.Model;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.References;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Models.Clients;
using Webmall.UI.ViewModel.Address;

namespace Webmall.UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly ICmsRepository _cmsRepository;
        private readonly IAddressRepository _addressRepository;

        public AddressController(ICmsRepository cmsRepository, IAddressRepository addressRepository)
        {
            _cmsRepository = cmsRepository;
            _addressRepository = addressRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            var client = SessionHelper.CurrentClient;
            //var clientId = SessionHelper.CurrentClientId;
            var model = new DeliveryAddressesViewModel
            {
                Addresses = new DeliveryAddressesModel
                {
                    Client = client,
                    Addresses = _addressRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, client?.Id,
                        UserPreferences.CurrentCulture),
                    AllowEdit = true,
                    MaxAddresses = _cmsRepository.GetDeliveryConfig().MaxAdressesCount,
                },
                Client = client,
                Regions = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture, ConfigHelper.CountryCode)
                    .Select(i => new SelectListItem {Text = i.Value, Value = i.Id}).ToList()
            };

            return View(model);
        }
        

        [Authorize]
        public PartialViewResult DeliveryAddresses()
        {
            var client = SessionHelper.CurrentClient;
            //var clientId = SessionHelper.CurrentClientId;
            var model = new DeliveryAddressesModel
            {

                Client = client,
                Addresses = _addressRepository.GetDeliveryAddresses(SessionHelper.CurrentUser, client?.Id, UserPreferences.CurrentCulture),
                AllowEdit = true,  //SessionHelper.IsGross,
                //EditCallback = editCallback,
                //MaxAddresses = _cmsRepository.GetDeliveryConfig().MaxAdressesCount,
            };

            return PartialView("DeliveryAddresses", model);
        }

        public JsonResult GetRegions(string term = "")
        {
            var result = SimpleReferenceItem.Convert(_addressRepository.GetRegions(null, UserPreferences.CurrentCulture)
                    //.Where(s => s.Name.ToLower().StartsWith(term.ToLower()))
                    , false)
                .OrderBy(i => i.Text)
                .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // ReSharper disable once InconsistentNaming
        public JsonResult GetLocalities(string regionId, bool withCarrier = false, string term = "")
        {
            var result = SimpleReferenceItem.Convert(_addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, regionId, withCarrier: withCarrier)
                    .Where(s => string.IsNullOrEmpty(term) || s.Value.ToLower().StartsWith(term.ToLower())), false).OrderBy(i => i.Text)
                .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCarriers(string localityId)
        {
            var clientId = SessionHelper.CurrentClientId;
            var result = SimpleReferenceItem.Convert(_addressRepository.GetCarriers(localityId, clientId).OrderBy(i => i.Name)
                .Select(i => new SimpleReferenceItem { Id = i.Id, Value = i.Name }), false)
                .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCarrierPickupPoints(string localityId, string carrierId)
        {
            if (string.IsNullOrEmpty(localityId) || string.IsNullOrEmpty(carrierId))
                return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            var result = SimpleReferenceItem.Convert(_addressRepository.GetCarrierPickupPoints(localityId, carrierId).OrderBy(i => i.Name)
                .Select(i => new SimpleReferenceItem { Id = i.Id, Value = i.Name }), false)
                .Select(i => new { id = i.Value, value = i.Text, label = i.Text });
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

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

        public ActionResult Delete(string id)
        {
            _addressRepository.RemoveDeliveryAddress(id, SessionHelper.CurrentClientId);
            return null;
        }

        public PartialViewResult DeletePartial(string id)
        {
            _addressRepository.RemoveDeliveryAddress(id, SessionHelper.CurrentClientId);
            return DeliveryAddresses();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveAddressNew(DeliveryAddress address)
        {
            if (SessionHelper.CurrentClientId != null)
            {
                FillDeliveryData(address);
                _addressRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId,
                    address);
            }

            return RedirectToAction("Index");
        }

        private void FillDeliveryData(DeliveryAddress address)
        {
            address.RegionName = _addressRepository.GetRegions(null, UserPreferences.CurrentCulture)
                .FirstOrDefault(i => i.Id == address.RegionId)?.Value;
            address.LocalityName = _addressRepository.GetLocalities(null, UserPreferences.CurrentCulture, address.RegionId, withCarrier: true)
                .FirstOrDefault(i => i.Id == address.LocalityId)?.Value;
            address.CarrierService = _addressRepository.GetCarriers(address.LocalityId, SessionHelper.CurrentClientId)
                .FirstOrDefault(i => i.Id == address.CarrierServiceId);
            address.PickupPoint = _addressRepository.GetCarrierPickupPoints(address.LocalityId, address.CarrierServiceId)
                .FirstOrDefault(i => i.Id == address.PickupPointId);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public PartialViewResult SaveAddress(DeliveryAddress address)
        {
            if (SessionHelper.CurrentClientId != null)
                _addressRepository.SaveDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, address);
            return DeliveryAddresses();
        }

        public JsonResult SetDefaultDeliveryAddress(string clientId, string addressId)
        {
            if (SessionHelper.CurrentClientId != null)
                _addressRepository.SetDefaultDeliveryAddress(SessionHelper.CurrentUser, SessionHelper.CurrentClientId, addressId);
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
