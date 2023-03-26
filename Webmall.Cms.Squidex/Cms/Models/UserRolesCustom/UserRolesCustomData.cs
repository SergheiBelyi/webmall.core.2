using Newtonsoft.Json;
using Squidex.ClientLibrary;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.UserRolesCustom
{
    public class UserRolesCustomData : CmsItemEntity
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Code;
        public LString Name;
    }
}
