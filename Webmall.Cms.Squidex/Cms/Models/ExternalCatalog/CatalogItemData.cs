using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.ExternalCatalog
{
    public class CatalogItemData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Category;
        public LString Name;
        public LString Description;
        [JsonConverter(typeof(InvariantConverter))]
        public string Url;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Content;
        [JsonConverter(typeof(InvariantConverter))]
        public string Icon;
    }
}
