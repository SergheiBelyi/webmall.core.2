using Webmall.Model.Entities.Address;

namespace Webmall.Model.Entities.Delivery
{
    /// <summary>
    /// Адрес доставки
    /// </summary>
    public class DeliveryAddress : Address.Address
    {
        /// <summary>
        /// Является адресом по умолчанию
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Можно удалить
        /// </summary>
        public bool IsDeletePossible { get; set; }

        /// <summary>
        /// Разрешен наложенный платеж
        /// </summary>
        public bool CanTakeMoney => PickupPoint?.CanTakeMoney ?? CarrierService?.CanTakeMoney ?? false;

        /// <summary>
        /// Является точкой выдачи
        /// </summary>
        public bool IsDeliveryPoint { get; set; }

        public string DeliveryPointOwner { get; set; }

        public bool Equals(DeliveryAddress address)
        {
            return Zip.Equals(address.Zip) && StreetId == address.StreetId && LocalityId == address.LocalityId
                   && House.Equals(address.House) && Flat.Equals(address.Flat);
        }

        /// <summary>
        /// Допускается выбор
        /// </summary>
        public bool IsSelectable { get; set; }

        public string AddressPresentator => (IsDeliveryPoint ? DeliveryPointOwner + " - " : "") + FullAddress;

        /// <summary>
        /// Идентификатор перевозчика
        /// </summary>
        public string CarrierServiceId { get; set; }

        /// <summary>
        /// Данные перевозчика
        /// </summary>
        public CarrierServiceInfo CarrierService { get; set; }

        /// <summary>
        /// Идентификатор точки выдачи
        /// </summary>
        public string PickupPointId { get; set; }

        /// <summary>
        /// Данные точки выдачи
        /// </summary>
        public PickupPointInfo PickupPoint { get; set; }

        public Receiver Receiver { get; set; }

    }
}