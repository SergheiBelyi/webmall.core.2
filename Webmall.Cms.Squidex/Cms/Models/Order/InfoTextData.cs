using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Order
{
    public class InfoTextData
    {
        public LString Name { get; set; }
        public LString Description { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public string ColorName { get; set; }
    }
}
