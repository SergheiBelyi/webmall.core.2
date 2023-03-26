using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.CatalogNews
{
    public class CatalogNewsData : CmsItemEntity
    {
        public LString Header;
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsActive;
        [JsonConverter(typeof(InvariantConverter))]
        public int Sort;
    }
}
