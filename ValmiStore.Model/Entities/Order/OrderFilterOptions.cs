using System;

namespace Webmall.Model.Entities.Order
{
    public class OrderFilterOptions
    {
        /// <summary>
        /// Начало периода оформления заказа
        /// </summary>
        public string DateFrom { get; set; } = DateTime.Today.AddMonths(-1).ToString("dd.MM.yyyy");

        /// <summary>
        /// Конец периода оформления заказа
        /// </summary>
        public string DateTo { get; set; }

        /// <summary>
        /// Начало периода доставки заказа
        /// </summary>
        public string DeliveryDateFrom { get; set; }

        /// <summary>
        /// Конец периода доставки заказа
        /// </summary>
        public string DeliveryDateTo { get; set; }

        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Каталожный номер товара в заказе (по вхождению)
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// Наименование брэнда в заказе (по вхождению)
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Наименование товара в заказе (по вхождению)
        /// </summary>
        public string WareName { get; set; }

        /// <summary>
        /// Код статуса заказа
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// Код типа оплаты
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Код типа доставки
        /// </summary>
        public string DeliveryTypeId { get; set; }

        /// <summary>
        /// Имя пользователя магазина, создавшего заказ (по вхождению)
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Код пользователя магазина, создавшего заказ
        /// </summary>
        public string AuthorId { get; set; }
    }
}
