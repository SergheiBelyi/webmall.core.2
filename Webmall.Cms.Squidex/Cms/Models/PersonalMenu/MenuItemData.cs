using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.PersonalMenu
{
    public class MenuItemData : CmsItemEntity
    {
        public LString Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Link { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public int Sort { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public int Column { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Parent { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string[] Roles { get; set; }
    }
}
