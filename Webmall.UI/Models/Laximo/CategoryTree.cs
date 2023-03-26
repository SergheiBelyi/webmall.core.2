using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;
using Webmall.Model.Abstract;

namespace Webmall.UI.Models.Laximo
{
    public class CategoryTree : ICommonTreeComposite<Category>
    {
        private readonly List<ICommonTreeComposite<Category>> _children = new List<ICommonTreeComposite<Category>>();
        private readonly Category _category = new Category();
        public string Id { 
            get => _category.Id;
            set { } 
        }

        public string Name
        {
            get => _category.Name;
            set { } 
        }

        public string Url { 
            get => _category.Id;
            set { }
        }
        public List<ICommonTreeComposite<Category>> Children => _children;

        public Category Category => _category;

        public CategoryTree() { }

        public CategoryTree(Category item)
        {
            _category = item;
            _children = item.Children.Select(i => (ICommonTreeComposite<Category>)new CategoryTree(i)).ToList();
        }
    }
}