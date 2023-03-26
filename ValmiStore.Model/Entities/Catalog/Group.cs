using System.Collections.Generic;
using Webmall.Model.Abstract;

namespace Webmall.Model.Entities.Catalog
{
    public class Group : ITreeComposite<Group>
    {
        private string _url;

        public Group()
        {
            SubGroups = new List<Group>();
        }

        public string Id { get; set; }
        public IEnumerable<Group> Children => SubGroups;
        public string Name { get; set; }
        public string ParentId { get; set; }
        public int Order { get; set; }
        public bool ShowInMenu { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Url
        {
            get => (ParentId != null && !string.IsNullOrEmpty(Parent?.Url) ? Parent.Url + "/" : "") + (string.IsNullOrEmpty(_url) ? Id : _url);
            set => _url = value?.Trim();
        }

        public Group Parent { get; set; }

        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; }

        public List<Group> SubGroups { get; set; }
    }
}
