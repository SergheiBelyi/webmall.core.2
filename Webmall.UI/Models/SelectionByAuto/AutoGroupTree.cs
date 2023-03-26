using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Abstract;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Models.SelectionByAuto
{
    public class AutoGroupTree : ICommonTreeComposite<Group>
    {
        private readonly List<ICommonTreeComposite<Group>> _children = new List<ICommonTreeComposite<Group>>();
        private readonly Group _group = new Group();
        public string Id { 
            get => _group.Id;
            set { } 
        }

        public string Name
        {
            get => _group.Name;
            set { } 
        }

        public string Url { 
            get => Id;
            set { }
        }

        public List<ICommonTreeComposite<Group>> Children => _children;

        public Group Group => _group;

        public Group Category => _group;

        public AutoGroupTree() { }

        public AutoGroupTree(Group item)
        {
            _group = item;
            _children = item.Children.Select(i => (ICommonTreeComposite<Group>)new AutoGroupTree(i)).ToList();
        }

        public AutoGroupTree Find(string id)
        {
            if (Id == id) 
                return this;
            return _children.Select(child => ((AutoGroupTree) child).Find(id)).FirstOrDefault(found => found != null);
        }
    }
}