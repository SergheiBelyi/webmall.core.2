using System.Collections.Generic;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.ViewModel.Catalog
{
    public class GroupsListViewModel
    {
        public string Title { get; set; }
        public List<Group> CurrentLevel { get; set; }
        public List<Group> SubGroups { get; set; }
        public List<BreadCrumbsModel> BreadCrumbs { get; set; }
    }
}