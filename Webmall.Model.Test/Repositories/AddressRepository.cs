using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.References;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressTestData _testData;

        public AddressRepository()
        {
            _testData = new AddressTestData();
        }

        public List<DeliveryAddress> GetDeliveryAddresses(User user, string clientId, string culture)
        {
            return _testData.DeliveryAddresses;
        }

        public virtual void RemoveDeliveryAddress(string id, string clientId)
        {
            _testData.DeliveryAddresses.Remove(
                _testData.DeliveryAddresses.FirstOrDefault(i => i.AddressId == id));
        }

        public void SaveDeliveryAddress(User user, string clientId, DeliveryAddress deliveryAddress)
        {
            if (string.IsNullOrEmpty(deliveryAddress.AddressId))
            {
                deliveryAddress.AddressId = Guid.NewGuid().ToString();
            }
            else
            {
                _testData.DeliveryAddresses.Remove(
                    _testData.DeliveryAddresses.FirstOrDefault(i => i.AddressId == deliveryAddress.AddressId));
            }
            _testData.DeliveryAddresses.Add(deliveryAddress);
        }

        public void SetDefaultDeliveryAddress(User user, string clientId, string id)
        {
            var addr = _testData.DeliveryAddresses.FirstOrDefault(i => i.AddressId == id);
            if (addr != null)
            {
                foreach (var item in _testData.DeliveryAddresses.Where(i=>i.IsDefault))
                {
                    item.IsDefault = false;
                }

                addr.IsDefault = true;
            }
        }

        public virtual List<SimpleReferenceItem> GetRegions(User user, string culture, string countryId = null)
        {
            //throw new NotImplementedException();
            return new List<SimpleReferenceItem> { new SimpleReferenceItem { Id = "1", Value = "Тестовый регион"} };
        }

        public virtual List<LocalityReference> GetLocalities(User user, string culture, string regionId, string countryId = null, bool withCarrier = false)
        {
            return new List<LocalityReference> { new LocalityReference { Id = "1", Value = "Тестовый город" } };
        }

        public virtual List<StreetReference> GetStreets(string culture, int? cityId)
        {
            throw new NotImplementedException();
        }

        public virtual List<CarrierServiceInfo> GetCarriers(string localityId, string clientId)
        {
            return new List<CarrierServiceInfo> { new CarrierServiceInfo { Id = "1", Name = "Тестовый перевозчик" } };
        }

        public virtual List<PickupPointInfo> GetCarrierPickupPoints(string localityId, string carrierId)
        {
            return new List<PickupPointInfo> { new PickupPointInfo { Id = "1", Name = "Тестовая точка выдачи" } };
        }
    }
}
