using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms.Brand
{
    public class BrandArticle : SeoBase
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public LString Header { get; set; }
        public LString FullText { get; set; }
    }
}