using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.SeoTemplate
{
    public class SeoTemplateData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Type;
        
        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
