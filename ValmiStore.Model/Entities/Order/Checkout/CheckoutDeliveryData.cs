namespace Webmall.Model.Entities.Order.Checkout
{
    /// <summary>
    /// Параметры доставки при создании заказа
    /// </summary>
    public class CheckoutDeliveryData
    {
        /// <summary>
        /// Тип отгрузки (1 – самовывоз, 2 – доставка)
        /// </summary>
        public int DeliveryTypeId { get; set; }

        /// <summary>
        /// Информация о самовывозе (заполняется для типа отгрузки = 1)
        /// </summary>
        public PickUpPayload PickUpPayload { get; set; }

        /// <summary>
        /// Информация о доставке (заполняется для типа отгрузки = 2)
        /// </summary>
        public DeliveryPayload DeliveryPayload { get; set; }
    }
}