using Webmall.Model.Entities.Delivery;

namespace Webmall.Model.Entities.Order
{
    public class DeliveryPayload
    {
        /// <summary>
        /// Идентификатор адреса доставки
        /// </summary>
        public string AddressId { get; set; }

        /// <summary>
        /// Идентификатор службы доставки
        /// </summary>
        public string TransporterServiceId { get; set; }

        /// <summary>
        /// Идентификатор точки выдачи
        /// </summary>
        public string PickupPointId { get; set; }

        /// <summary>
        /// Код способа доставки
        /// </summary>
        public string DeliveryMethodId { get; set; }

        /// <summary>
        /// Наименование способа доставки
        /// </summary>
        public string DeliveryMethodName { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public DeliveryTime DeliveryTime { get; set; }

        /// <summary>
        /// Необходимость страхования доставки
        /// </summary>
        public bool Insurance { get; set; }

        /// <summary>
        /// Доставлять по доступности
        /// </summary>
        public bool? DeliveryAvailable { get; set; }
    }
}