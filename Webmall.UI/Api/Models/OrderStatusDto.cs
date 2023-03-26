using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    public class OrderStatusDto
    {
        [JsonProperty("color")] public string Color { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("value")] public string Value { get; set; }
    }
}