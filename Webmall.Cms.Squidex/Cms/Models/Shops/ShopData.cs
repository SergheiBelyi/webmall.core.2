using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using Webmall.Cms.Squidex.Core.Model;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Shops
{
    public class ShopData : CmsItemEntity
    {
        public LString Name;
        public LString ShortName;
        [JsonConverter(typeof(InvariantConverter))]
        public int Sort;
        [JsonConverter(typeof(InvariantConverter))]
        public string[] Image;
        [JsonConverter(typeof(InvariantConverter))]
        public Location Location;
        [JsonConverter(typeof(InvariantConverter))]
        public List<Phones> Phones;
        public Dictionary<string, List<Schedule>> Schedule;
        public LString MetaTitle;
        public LTag MetaKeywords;
        public LString MetaDescription;
    }
}
