using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Abstract;

namespace ValmiStore.Model.Entities
{
    [Serializable]
    public class Group : ITreeComposite<Group>
    {
        private string id;
        private string _url;
        private string parentId;

        public string Id
        {
            get => id;
            set => id = value?.Trim();
        }
        public string WareGroupId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string ParentId
        {
            get => parentId;
            set => parentId = value?.Trim();
        }
        public int Order { get; set; }
        public string OrderName { get; set; }
        public Group Parent { get; set; }
        public List <Group> SubGroup { get; set; }
        public string Title { get; set; }
        public string PageHeader { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public string ThemeText { get; set; }
        public List<Producer> Brands { get; set; }
        public bool IsBrand { get; set; }
        public string BrandId { get; set; }
        public string WareType { get; set; }
        public string AdditionalHtmlText { get; set; }
        public string ImageUrl { get; set; }
        //{
        //    get { return "/Content/images/size-shina.gif"; }
        //}

        public string Url
        {
            get => (ParentId != null && !string.IsNullOrEmpty(Parent?.Url) ? Parent.Url + "/" : "") + (string.IsNullOrEmpty(_url) ? Id : _url);
            set => _url = value?.Trim();
        }

        //public string FullURL { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; } = false;


        public Group()
        {
            SubGroup = new List<Group>();
        }

        /// <summary>
        /// Конструктор псевдогруппы
        /// </summary>
        /// <param name="parent">Группа-родитель</param>
        /// <param name="item">Производитель</param>
        /// <param name="trendCode">Код направления</param>
        public Group(Group parent, Producer item, string trendCode)
        {
            ParentId = parent.Id;
            Id = "-"+ParentId + item.Id.PadLeft(5,' ');
            WareGroupId = item.Id; 
            Name = item.Name;
            Title = parent.Title + " " + Name;
            Order = 0;
            PageHeader = parent.PageHeader + " " + Name;
            ThemeText = parent.ThemeText;
            Url = item.URL?.ToLower();
            Description = parent.Description;
            Keywords = parent.Keywords + " " + Name;
            SubGroup = new List<Group>();
            IsNew = false;
            Parent = parent;
            IsBrand = true;
            BrandId = item.Id;
            WareType = parent.WareType;
            AdditionalHtmlText = parent.AdditionalHtmlText;
        }

        public IEnumerable<Group> Children => SubGroup;

        public bool HasSubGroups => SubGroup != null && SubGroup.Any();
    }
}