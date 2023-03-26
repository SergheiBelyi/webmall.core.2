using System;
using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class OrderPositionDto
    {
        [JsonProperty("id")] public string PositionId { get; set; }
        [JsonProperty("wareId")] public string WareId { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("brand")] public string Brand { get; set; }
        [JsonProperty("total")] public decimal? Total { get; set; }
        [JsonProperty("price")] public decimal? Price { get; set; }
        [JsonProperty("quantity")] public int Quantity { get; set; }
        [JsonIgnore] public int WarehouseQuantity { get; set; }
        [JsonProperty("warehouse")] public string Warehouse { get; set; }
        [JsonProperty("deliveryTerm")] public DateTime? DeliveryTerm { get; set; }
        [JsonProperty("errorMessage")] public string ErrorMessage { get; set; }
        [JsonProperty("warningMessage")] public string WarningMessage { get; set; }
        [JsonProperty("inReserve")] public bool InReserve { get; set; }
        [JsonProperty("weight")] public decimal Weight { get; set; }
    }
}