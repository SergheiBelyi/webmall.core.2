using System;
using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class OrderDto
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("positions")] public OrderPositionDto[] Positions { get; set; }
        [JsonProperty("total")] public decimal? Total { get; set; }
        [JsonProperty("payment")] public PaymentDto Payment { get; set; }
        [JsonProperty("paymentType")] public int PaymentType { get; set; }
        [JsonProperty("payerEmail")] public string PayerEmail { get; set; }
        [JsonProperty("comment")] public string Comment { get; set; }
        
        /// <summary>
        /// Признак наличия задолженности у клиента
        /// if true => allow only SelfDelivery
        /// </summary>
        [JsonProperty("hasDebt")] public bool HasDebt { get; set; }

        /// <summary>
        /// Сумма оставшегося лимита
        /// </summary>
        [JsonProperty("limit")] public int Limit { get; set; }

        /// <summary>
        /// Сообщение о наличии задолженности у клиента для вывода в форме заказа
        /// </summary>
        [JsonProperty("debtMessage")] public string DebtMessage { get; set; }

        [JsonProperty("warehouseId")]
        public string WarehouseId { get; set; }

        /// <summary>
        /// Склад отгрузки
        /// </summary>
        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; }

        /// <summary>
        /// Заказ доступен с
        /// </summary>
        [JsonProperty("availabilityDatePresenter")]
        public string AvailabilityDatePresenter { get; set; }

        /// <summary>
        /// Отсрочка платежа, дней
        /// </summary>
        [JsonProperty("delayPresenter")]
        public string DelayPresenter { get; set; }

        /// <summary>
        /// Тип доставки
        /// </summary>
        [JsonProperty("deliveryType")]
        public string DeliveryType { get; set; }

        /// <summary>
        /// адрес доставки
        /// </summary>
        [JsonProperty("deliveryAddressPresenter")]
        public string DeliveryAddressPresenter { get; set; }

        /// <summary>
        /// адрес доставки
        /// </summary>
        [JsonProperty("deliveryAddressId")]
        public string DeliveryAddressId { get; set; }

        [JsonProperty("deliveryTypeId")]
        public string DeliveryTypeId { get; set; }

        [JsonProperty("deliveryArrivalTime")]
        public DateTime? DeliveryArrivalTime { get; set; }

        /// <summary>
        /// Код статус заказа
        /// </summary>
        [JsonProperty("statusId")]
        public string StatusId { get; set; }

        [JsonProperty("deliverySchedule")]
        public DateTime[] DeliverySchedule { get; set; }

        /// <summary>
        /// Наименование валюты заказа
        /// </summary>
        [JsonProperty("valuteName")]
        public string ValuteName { get; set; }

        /// <summary>
        /// Общий вес заказа
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Объщий объем заказа
        /// </summary>
        [JsonProperty("volume")]
        public string Volume { get; set; }

        /// <summary>
        /// Разрешение самовывоза
        /// </summary>
        [JsonProperty("allowPickup")]
        public bool AllowPickup { get; set; } = true;

        /// <summary>
        /// Код валюты
        /// </summary>
        [JsonProperty("currencyCode")] public string CurrencyCode { get; set; }
    }
}