using Newtonsoft.Json;
using Squidex.ClientLibrary;

namespace Webmall.Cms.Squidex.Config.Models.Email
{
    public class EmailConfigData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public bool SSLEnabled = true;
    }
}
