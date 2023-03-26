using System.Collections.Generic;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities
{
    public class Home
    {
        public string Text { get; set; }
        public SeoTemplate SeoTemplate { get; set; }
        public List<Group> PopularGroups { get; set; }
    }
}