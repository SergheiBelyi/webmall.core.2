using Newtonsoft.Json;

namespace Webmall.UI.Api.Models
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class ValuteDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("shortName")]
        public string ShortName { get; set; }
    }
}
