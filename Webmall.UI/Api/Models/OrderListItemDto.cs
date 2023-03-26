using System;
using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class OrderListResponse
    {
        [JsonProperty("list")]
        public OrderListItemDto[] List { get; set; }
        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public class OrderListItemDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("orderDate")] public DateTime OrderDate { get; set; }

        [JsonProperty("warehouse")] public string Warehouse { get; set; }

        [JsonProperty("sum")] public decimal? Sum { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("needToPay")] public bool NeedToPay { get; set; }

        [JsonProperty("deliveryAddress")] public string DeliveryAddress { get; set; }
        [JsonProperty("canDelete")] public bool CanDelete { get; set; }
        [JsonProperty("canChange")] public bool CanChange { get; set; }
        [JsonProperty("deleteBlockMessage")] public string DeleteBlockMessage { get; set; }
        [JsonProperty("isPayed")] public bool IsPayed { get; set; }
        [JsonProperty("isReserved")] public bool IsReserved { get; set; }
        [JsonProperty("statusId")] public string StatusId { get; set; }
        [JsonProperty("currencyCode")] public string CurrencyCode { get; set; }

    }
}