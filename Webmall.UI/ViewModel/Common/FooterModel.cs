using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.Footer;

namespace Webmall.UI.ViewModel.Common
{
    public class FooterModel
    {
        public Contact ContactInfo { get; set; } = new Contact();
        public List<FooterColumn> Columns { get; set; } = new List<FooterColumn>();
        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
    }
}