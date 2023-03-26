using Webmall.Model.Entities.User;
using Webmall.UI.Core;

namespace Webmall.UI.Models.UserManagement
{
    public class UserListModel
    {
        public GridViewModel<User> Users { get; set; }

        public UserFilter Filter { get; set; }
    }
}