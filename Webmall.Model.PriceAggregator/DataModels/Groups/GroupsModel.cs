
using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    public class GroupsModel
    {
        public GroupsModel()
        {
            SubGroups = new List<GroupsModel>();
        }
        public string Id { get; set; }
        public string Name {get; set;}
        public string ParentId {get; set;}
        public bool UseInWebShop {get; set;}
        public int Order {get; set;}
        public string Title {get; set;}
        public string Keywords {get; set;}
        public string Description {get; set;}
        public string Url {get; set;}
        public string Text {get; set;}
        public string IsNew {get; set;}
        public string ImageUrl {get; set;}
        public string Image {get; set;}
        public List<GroupsModel> SubGroups { get; set; }
    }
}
