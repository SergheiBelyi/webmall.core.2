using System.Collections.Generic;
using Webmall.Model.Entities.Address;
using Webmall.Model.Entities.Delivery;

namespace Webmall.Model.Test.Repositories.TestData
{
    public class AddressTestData
    {
        public List<DeliveryAddress> DeliveryAddresses => _deliveryAddresses;
        private static readonly List<DeliveryAddress> _deliveryAddresses = new List<DeliveryAddress>
            {
                new DeliveryAddress
                {
                    AddressId = "1", Comment = "Comment 1",
                    RegionId = "1", RegionName = "Запорожская обл.", LocalityId = "000008417", LocalityName = "Азовське",
                    CarrierServiceId = "4", CarrierService = new CarrierServiceInfo {Name = "Нова пошта"},
                    PickupPointId = "15867",
                    PickupPoint = new PickupPointInfo {Name = "Пункт приймання-видачі (до 30 кг):вул. Центральна 34"},
                    AddressLine = "бульвар Александрийский 39",
                    Receiver = new Receiver { Name = "Руслан Максимюк", Email = "massacars2@gmail.com", Phone = "+38 (097)-872-37-00" },
                    StreetId = "1", StreetName = "Street 1", House = "1/1", Flat = "1",
                    Zip = "MD-1111", IsDefault = true, IsDeletePossible = false, IsSelectable = true
                },
                new DeliveryAddress
                {
                    AddressId = "2",
                    Comment = "Comment 2",
                    RegionId = "4",
                    RegionName = "Київська обл.",
                    LocalityId = "000000003",
                    LocalityName = "Київ",
                    CarrierServiceId = "11",
                    CarrierService = new CarrierServiceInfo { Name = "САМОВЫВОЗ" },
                    PickupPointId = "17176",
                    PickupPoint = new PickupPointInfo { Name = "Самовывоз Балтийский 20" },
                    AddressLine = "Балтийский 20",
                    Receiver = new Receiver { Name = "Получатель", Email = "massacars@gmail.com", Phone = "+38 (097) - 872 - 37 - 00" },
                    StreetId = "1",
                    StreetName = "Street 1",
                    House = "1/1",
                    Flat = "1",
                    Zip = "MD-1111",
                    IsDefault = true,
                    IsDeletePossible = false,
                    IsSelectable = true
                },
                new DeliveryAddress
                {
                    AddressId = "2",
                    Comment = "Comment 2",
                    RegionId = "2",
                    RegionName = "Region 2",
                    LocalityId = "2",
                    LocalityName = "Locality 2",
                    StreetId = "2",
                    StreetName = "Street 2",
                    House = "2/2",
                    Flat = "2",
                    Zip = "MD-2222",
                    IsDefault = true,
                    IsDeletePossible = false,
                    IsSelectable = true
                }
            };
    }
}