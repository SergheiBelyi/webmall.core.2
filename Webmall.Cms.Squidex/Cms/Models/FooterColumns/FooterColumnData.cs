using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.FooterColumns
{
    public class FooterColumnData : CmsItemEntity
    {
        [JsonConverter(typeof(InvariantConverter))]
        public int OrderNumber;
        public LString Title;
        [JsonConverter(typeof(InvariantConverter))]
        public string Id;
    }
}
