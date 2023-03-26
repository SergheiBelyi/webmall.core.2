using Newtonsoft.Json;
using Squidex.ClientLibrary;

namespace Webmall.Cms.Squidex.Cms.Models.SocialLinks
{
    public class SocialLinkData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public int OrderNumber;
        [JsonConverter(typeof(InvariantConverter))]
        public string Type;
        [JsonConverter(typeof(InvariantConverter))]
        public string Url;
        [JsonConverter(typeof(InvariantConverter))]
        public string CssClass;
        [JsonConverter(typeof(InvariantConverter))]
        public string IconName;
    }
}
