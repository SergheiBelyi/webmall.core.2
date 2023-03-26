using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.HeaderNav
{
    public class HeaderNavData
    {
        public LString Name;
        public LString Url;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
        [JsonConverter(typeof(InvariantConverter))]
        public string Icon;
        [JsonConverter(typeof(InvariantConverter))]
        public int Sort;
    }
}
