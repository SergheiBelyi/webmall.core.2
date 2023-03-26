using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms
{
    public class WareGroups : SeoBase
    {
        public string IdGroup { get; set; }
        public LString Name { get; set; }
        public int Order { get; set; }
        public string Slug { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; }
    }
}
