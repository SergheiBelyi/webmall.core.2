using Webmall.Model.Entities.Cart;

namespace Webmall.Model.Entities.Order.Checkout
{
    /// <summary>
    /// Данные для создания заказа
    /// </summary>
    public class CheckoutOrderData
    {
        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Код пользователя ИМ
        /// </summary>
        public string AuthorId { get; set; }

        /// <summary>
        /// Имя пользователя ИМ – автора заказа
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Код склада с которого оформляется заказ (берется из Client.CurrentWarehouseId)
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Список позиций корзины, для которых создается заказ
        /// </summary>
        public CartPosition[] Positions { get; set; }

        /// <summary>
        /// Информация о дополнительных параметрах заказа
        /// </summary>
        public OrderOptions Options { get; set; }

        /// <summary>
        /// Информация о выбранном способе доставки
        /// </summary>
        public CheckoutDeliveryData Delivery { get; set; }

        /// <summary>
        /// Информация о выбранном способе оплаты
        /// </summary>
        public CheckoutPaymentData Payment { get; set; }
    }
}