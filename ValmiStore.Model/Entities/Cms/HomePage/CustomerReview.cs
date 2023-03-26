using System;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms.HomePage
{
    public class CustomerReview : SeoBase
    {
        public LString CustomerName { get; set; }
        public string Image { get; set; }
        public LString ShortText { get; set; }
        public DateTime Date { get; set; }
        public bool IsScroll { get; set; }
        public string Slug { get; set; }
        public LString FullText { get; set; }
    }
}
