using System.Collections.Generic;
using System.Linq;

namespace Webmall.Model.Entities.Cms.PersonalMenu
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }

        public MenuItem this[string id] => MenuItems.FirstOrDefault(i => i.Id == id);

        public MenuItem[] this[string[] roles] => MenuItems.Where(i=>i.Roles == null || i.Roles.Any(r=>roles.Contains(r.Code))).ToArray();
    }
}
