using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.IncorporatingText
{
    public class IncorporatingTextData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;
        public LString Text;
    }
}
