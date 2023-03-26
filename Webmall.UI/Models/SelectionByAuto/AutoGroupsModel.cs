using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Abstract;
using Webmall.Model.Entities.Auto;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Models.SelectionByAuto
{
    [Serializable]
    public class AutoGroupsModel
    {
        public AutoModification VehicleInfo { get; set; }

        public List<ICommonTreeComposite<Group>> Groups { get; set; }

        //public List<KeyValuePair<string, Group>> GroupList { get; set; }

        public List<WareListItem> Wares { get; set; }
        public ICommonTreeComposite<Group> SelectedGroup { get; set; }

        public ICommonTreeComposite<Group> Find(string id, List<ICommonTreeComposite<Group>> groups)
        {
            if (id == null)
                return null;
            foreach (var group in groups)
            {
                if (group.Id == id) return group;
                if (group.Children != null && group.Children.Any())
                {
                    var result = Find(id, group.Children);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        public List<KeyValuePair<string, Group>> GetListFromTree(List<KeyValuePair<string, Group>> list, List<ICommonTreeComposite<Group>> groups, string parentPath)
        {
            if (list == null)
                list = new List<KeyValuePair<string, Group>>();
            foreach (var item in groups)
            {
                var gr = ((AutoGroupTree)item).Group;
                if (gr.Children.Any())
                    GetListFromTree(list, item.Children, parentPath + gr.Name + " / ");
                else
                    list.Add(new KeyValuePair<string, Group>(parentPath.TrimEnd(' ', '/'), gr));
            }
            return list;
        }

    }
}