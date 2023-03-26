using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms.Brand
{
    public class BrandItem : SeoBase
    {
        public string Image { get; set; }
        public string OriginalName { get; set; }
        public string Name { get; set; }
        public bool IsRecommended { get; set; }
        public bool? IsAction { get; set; }
        public string Articles { get; set; }
        public string Slug { get; set; }
        public int? Rating { get; set; }
        public int? Sort { get; set; }
        public string CountryOrigin { get; set; }
        public string LinkOrigin { get; set; }
        public string LinkCatalog { get; set; }
        public string ArticlesSlug { get; set; }

        public LArray<FeatureData> Features { get; set; }
        public LArray<GalleryItem> Gallery { get; set; }
        public LArray<DocsItem> Docs { get; set; }
        public LArray<BrandNewsItem> News { get; set; }

        public LString WarrantyTitle { get; set; }
        public string[] WarrantyImages { get; set; }


        public LString Marks { get; set; }
        public LString Assemblies { get; set; }
        public LString VehicleTypes { get; set; }
    }
}
