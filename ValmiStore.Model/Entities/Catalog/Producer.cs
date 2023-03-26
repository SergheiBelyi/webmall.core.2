
using Webmall.Model.Entities.Cms.Brand;

namespace Webmall.Model.Entities.Catalog
{
    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool OurProducer { get; set; }
        public string UrlName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsOEM { get; set; }
        public bool IsAction { get; set; }
        public string DescriptionText { get; set; }
        public string Country { get; set; }
        public string SiteUrl { get; set; }
        public string CatalogUrl { get; set; }
        public bool IsRecommended { get; set; }
        public BrandItem Brand { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
