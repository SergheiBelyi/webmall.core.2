using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Banners
{
    public class BannerData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Name;
        public LString Url;
        public LBoolean ForLanguage;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
    }
}
