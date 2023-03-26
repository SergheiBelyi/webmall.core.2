using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.WareGroup
{
    public class WareGroupData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string IdGroup { get; set; }
        public LString Name { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public int? Order { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string IconUrl { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string ImageUrl { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsNew { get; set; }

        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
