using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.ExternalCatalog
{
    public class CatalogCategoryData : CmsItemEntity
    {
        public LString Header;
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
    }
}
