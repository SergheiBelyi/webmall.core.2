using System.Collections.Generic;
using ValmiStore.Model.Entities;

namespace Webmall.UI.Models.SelectionByAuto
{
    public class SelectionByAutoGroups
    {
        public SelectionByAutoGroups()
        {
            Groups = new List<Group>();
        }

        public List<Group> Groups { get; set; }
        public Group SelectedGroup { get; set; }

        public string Type { get; set; }
    }
}