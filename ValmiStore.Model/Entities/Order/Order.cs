using System;
using System.Collections.Generic;

namespace Webmall.Model.Entities.Order
{
    public class Order
    {
        /// <summary>
        /// Идентификатор/номер заказа
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Дата+время оформления заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Сумма заказа
        /// </summary>
        public decimal? Sum { get; set; }

        /// <summary>
        /// Код статуса заказа
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// Наименование статуса заказа
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// Код пользователя/автора оформившего заказ
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Имя пользователя/автора оформившего заказ
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Список позиций заказа
        /// </summary>
        public List<OrderPosition> Positions { get; set; }

        /// <summary>
        /// Дополнительные характеристики заказа
        /// </summary>
        public OrderOptions Options { get; set; }
        
        /// <summary>
        /// Информация о доставке
        /// </summary>
        public DeliveryInfo DeliveryInfo { get; set; }

        /// <summary>
        /// Информация об оплате
        /// </summary>
        public PaymentInfo PaymentInfo { get; set; }

        /// <summary>
        ///  Признак возможности удалить заказ
        /// </summary>
        public bool CanDelete { get; set; }

        /// <summary>
        /// Сообщение о причинах невозможности удаления (при CanDelete = false)
        /// </summary>
        public string DeleteBlockMessage { get; set; }

        /// <summary>
        /// Признак возможности изменения заказа
        /// </summary>
        public bool? CanChange { get; set; }

        /// <summary>
        /// Сообщение о причинах невозможности изменения (при CanChange = false)
        /// </summary>
        public string ChangeBlockMessage { get; set; }

        public bool IsReserved { get; set; }

        /// <summary>
        /// Признак возможности печати акта приема-передачи
        /// </summary>
        public bool AllowTransmissionAct { get; set; }

    }
}