using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Menu
{
    public class MenuData : CmsItemEntity
    {
        [JsonConverter(typeof(InvariantConverter))]
        public int OrderNumber;
        public LString Title;
        public LString Url;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly { get; set; }
    }
}
