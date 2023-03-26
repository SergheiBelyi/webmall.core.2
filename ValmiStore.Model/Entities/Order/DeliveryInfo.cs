namespace Webmall.Model.Entities.Order
{
    public class DeliveryInfo
    {
        /// <summary>
        /// Код типа отгрузки (1 – самовывоз, 2 - доставка)
        /// </summary>
        public int DeliveryTypeId { get; set; }

        /// <summary>
        /// Код статуса доставки
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// Наименование статуса доставки
        /// </summary>
        public string StatusName { get; set; }

        public PickUpPayload PickUpPayload { get; set; }

        public DeliveryPayload DeliveryPayload { get; set; }
    }
}
