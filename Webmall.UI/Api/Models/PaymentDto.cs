using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Webmall.UI.Api.Models
{
    public class PaymentDto
    {
        [JsonProperty("paymentType")] public int PaymentType { get; set; }
        [JsonProperty("paymentPayload")] public JObject PaymentPayload { get; set; }
    }
}