using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.PersonalMenu
{
    public class MenuItem
    {
        public MenuItem()
        {
            Children = new List<MenuItem>();
        }

        public string Id { get; set; }
        public LString Name { get; set; }
        public string Link { get; set; }
        public int Sort { get; set; }
        public int ColumnNumber { get; set; }
        public string Image { get; set; }
        public List<MenuItem> Children { get; set; }
        public string[] RoleIds { get; set; }
        public List<UserRolesCustom> Roles { get; set; }
    }
}
