using System;

namespace Webmall.Model.Entities.Order
{
    public class OrderPosition
    {
        /// <summary>
        /// Идентификатор позиции заказа
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Код статуса позиции
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// Наименование статуса позиции
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        public string ProducerId { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public string WareId { get; set; }

        /// <summary>
        /// Артикул товара
        /// </summary>
        public string WareNumber { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string WareName { get; set; }

        /// <summary>
        /// Заказанное количество товара
        /// </summary>
        public decimal WareQnt { get; set; }

        /// <summary>
        /// Цена клиента
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Суммарная стоимость позиции
        /// </summary>
        public decimal Sum => Price * WareQnt;

        /// <summary>
        /// Комментарий к позиции корзины
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Информация о доставке
        /// </summary>
        public DeliveryInfo DeliveryInfo { get; set; } = new DeliveryInfo();

        /// <summary>
        /// Признак, что позиция в резерве
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// Вес позиции в кг за ед.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Дата время доставки
        /// </summary>
        public DateTime? DeliveryTerm { get; set; }

        public string DeliveryTermAsString => (!DeliveryTerm.HasValue) ? null :
            (DeliveryTerm.Value.Date == DeliveryTerm.Value) ? DeliveryTerm.Value.ToShortDateString() :
                DeliveryTerm.ToString();

        public string DeliveryPresentation => Helper.DeliveryTermPresentator(DeliveryTerm);

    }
}
