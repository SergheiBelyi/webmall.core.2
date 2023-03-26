using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;
using Webmall.Model.Abstract;

namespace Webmall.UI.Models.Laximo
{
    public class GroupTree : ICommonTreeComposite<QuickGroup>
    {
        private readonly List<ICommonTreeComposite<QuickGroup>> _children = new List<ICommonTreeComposite<QuickGroup>>();
        private readonly QuickGroup _group = new QuickGroup();
        public string Id { 
            get => _group.Id.ToString();
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
        public List<ICommonTreeComposite<QuickGroup>> Children => _children;

        public QuickGroup Group => _group;

        public QuickGroup Category => _group;

        public GroupTree() { }

        public GroupTree(QuickGroup item)
        {
            _group = item;
            _children = item.Children.Select(i => (ICommonTreeComposite<QuickGroup>)new GroupTree(i)).ToList();
        }
    }
}