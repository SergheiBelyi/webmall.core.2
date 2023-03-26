using Newtonsoft.Json;
using Squidex.ClientLibrary;

namespace Webmall.Cms.Squidex.Cms.Models.Menu
{
    public class MenuLevel2Data : MenuData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Level1;
    }
}
