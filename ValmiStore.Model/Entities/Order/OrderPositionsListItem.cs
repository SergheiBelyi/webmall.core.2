using System;

namespace Webmall.Model.Entities.Order
{
    public class OrderPositionsListItem
    {
        public OrderPosition PositionInfo { get; set; }

        /// <summary>
        /// Идентификатор/номер заказа
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Дата+время оформления заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientId { get; set; }
    }
}