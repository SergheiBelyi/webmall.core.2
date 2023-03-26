using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;
using Webmall.Model.Abstract;

namespace Webmall.UI.Models.Laximo
{
    [Serializable]
    public class GroupsModel : BaseModel
    {
        public VehicleInfo VehicleInfo { get; set; }

        public List<ICommonTreeComposite<QuickGroup>> Groups { get; set; }

        public List<KeyValuePair<string, QuickGroup>> GroupList { get; set; }

        public List<UnitInfo> Units { get; set; }
        public ICommonTreeComposite<QuickGroup> SelectedGroup { get; set; }

        public ICommonTreeComposite<QuickGroup> Find(string id, List<ICommonTreeComposite<QuickGroup>> groups)
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

        public List<KeyValuePair<string, QuickGroup>> GetListFromTree(List<KeyValuePair<string, QuickGroup>> list, List<ICommonTreeComposite<QuickGroup>> groups, string parentPath)
        {
            if (list == null)
                list = new List<KeyValuePair<string, QuickGroup>>();
            foreach (var item in groups)
            {
                var gr = ((GroupTree) item).Group;
                if (gr.Children.Any())
                    GetListFromTree(list, item.Children, parentPath + gr.Name + " / ");
                else
                    list.Add(new KeyValuePair<string, QuickGroup>(parentPath.TrimEnd(' ', '/'), gr));
            }
            return list;
        }

    }
}