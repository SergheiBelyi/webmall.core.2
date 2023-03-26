using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms
{
    public class Article : SeoBase
    {
        public string Id { get; set; }
        public LString Header { get; set; }
        public LString FullText { get; set; }
        public string Url { get; set; }
        public bool SendForSubscribers { get; set; }
        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
    }
}