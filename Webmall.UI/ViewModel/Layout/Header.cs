using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Contacts;
using Webmall.Model.Entities.Cms.Menu;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.User;

namespace Webmall.UI.ViewModel.Layout
{
    public class Header
    {
        public User User { get; set; }
        public Contact ContactInfo { get; set; } = new Contact();
        public List<MenuLevel1> Menu { get; set; } = new List<MenuLevel1>();
        public MenuItem[] PersonalMenu { get; set; } = new MenuItem[0];
    }
}