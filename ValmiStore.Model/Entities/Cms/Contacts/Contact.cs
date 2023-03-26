using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.Contacts
{
    public class Contact
    {
        public LString CompanyName { get; set; } = new LString();
        public List<Phones> Phones { get; set; } = new List<Phones>();
        public List<Emails> Emails { get; set; } = new List<Emails>();
        public LArray<Schedule> Schedule { get; set; } = new LArray<Schedule>();
        public LString MainOffice { get; set; } = new LString();
        public List<string> PaymentImg { get; set; } = new List<string>();
        public LArray<Info> Info { get; set; } = new LArray<Info>();
    }
}
