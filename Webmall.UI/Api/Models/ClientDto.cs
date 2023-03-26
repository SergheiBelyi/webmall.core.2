using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class ClientDto
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("valute")] public ValuteDto Valute { get; set; }
        [JsonProperty("allowedPaymentTypes")] public int[] AllowedPaymentTypes { get; set; }
        [JsonProperty("allowShipmentRequest")] public bool AllowShipmentRequest { get; set; }
        [JsonProperty("currentWarehouseId")] public string CurrentWarehouseId { get; set; }
        [JsonProperty("isGross")] public bool IsGross { get; set; }
    }
}