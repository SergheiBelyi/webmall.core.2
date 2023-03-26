using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.Localization;
using Webmall.Model.Entities.Cms.Seo;

namespace Webmall.Model.Entities.Cms.HomePage
{
    public class Shops : SeoBase
    {
        public string Id { get; set; }
        public LString Name { get; set; }
        public LString ShortName { get; set; }
        public int Sort { get; set; }
        public string[] Image { get; set; }
        public Location Location { get; set; }
        public List<Phones> Phones { get; set; }
        public Dictionary<string, List<Schedule>> Schedule { get; set; }
    }
}
