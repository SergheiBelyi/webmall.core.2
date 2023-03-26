using System;
using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class DeliveryDto
    {
        [JsonProperty("deliveryType")] public string DeliveryType { get; set; } // null - самовывоз
        [JsonProperty("pickupPointId")] public string PickupPointId { get; set; }
        [JsonProperty("addressId")] public string AddressId { get; set; } 
        [JsonProperty("deliveryDateTime")] public DateTime DeliveryDateTime { get; set; }
        [JsonProperty("isUrgentCollection")] public bool IsUrgentCollection { get; set; }
    }
}