using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.MailMessageTemplate
{
    public class MailMessageTemplateData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug;

        [JsonConverter(typeof(InvariantConverter))]
        public string Receivers;

        public LString Text;
    }
}
