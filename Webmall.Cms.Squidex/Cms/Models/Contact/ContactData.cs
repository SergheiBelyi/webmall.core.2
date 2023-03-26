using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Cms.Models.Contact
{
    public class ContactData
    {
        public LString CompanyName { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public List<Phones> Phones { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public List<Emails> Emails { get; set; }
        public LArray<Schedule> Schedule { get; set; }
        public LArray<Info> Info { get; set; }
        public LString MainOffice { get; set; }
        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Payment { get; set; }
    }

}
