using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.EmbeddedText
{
    public class EmbeddedTextData
    {
        public LString Name { get; set; }
        public LString Description { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public int Id { get; set; }
    }
}
