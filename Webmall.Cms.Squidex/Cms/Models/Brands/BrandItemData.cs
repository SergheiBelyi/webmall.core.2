using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Brands
{
    public class BrandItemData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string OriginalName { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRecommended { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public bool? IsAction { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Articles { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public int? Rating { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public int? Sort { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string CountryOrigin { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string LinkOrigin { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string LinkCatalog { get; set; }

        public LArray<object> Features { get; set; }

        public LArray<object> Gallery { get; set; }
        public LArray<object> Docs { get; set; }
        public LArray<object> News { get; set; }

        public LString WarrantyTitle { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string[] WarrantyImages { get; set; }

        public LTag Marks;
        public LTag Assemblies;
        public LTag VehicleTypes;

        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
