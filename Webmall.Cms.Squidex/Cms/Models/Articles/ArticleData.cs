using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Articles
{
    public class ArticleData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        public LString Header;
        public LString Full;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsForMailing;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsGrossOnly;
        [JsonConverter(typeof(InvariantConverter))]
        public bool IsRetailOnly;
        
        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;

    }
}
