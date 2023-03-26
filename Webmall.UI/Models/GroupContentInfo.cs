using ValmiStore.Model.Entities;
using Webmall.UI.Core;

namespace Webmall.UI.Models
{
    public class GroupContentInfo
    {
        public GridViewModel<Group> Groups { get; set; }
        public Group ActiveGroup { get; private set; }

        public GroupContentInfo ()
        {
            ActiveGroup = new Group();
        }
    }
}