namespace Webmall.Model.Entities.Order.Checkout
{
    public class SetOrderDeliveryData
    {
        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Код клиента
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Информация о выбранном способе доставки
        /// </summary>
        public CheckoutDeliveryData Delivery { get; set; }
    }
}