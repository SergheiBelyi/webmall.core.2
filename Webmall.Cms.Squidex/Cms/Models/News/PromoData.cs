using Newtonsoft.Json;
using Squidex.ClientLibrary;

namespace Webmall.Cms.Squidex.Cms.Models.News
{
    public class PromoData : NewsData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string MarketingActionLink { get; set; }
    }
}
