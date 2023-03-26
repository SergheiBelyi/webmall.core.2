using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.BrandArticles
{
    public class BrandArticleData : CmsItemEntity
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        public LString Header;
        public LString Full;
        
        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;

    }
}
