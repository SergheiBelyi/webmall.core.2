using System.Collections.Generic;

namespace Webmall.Model.Entities.Catalog
{
    public class GroupProperty
    {
        public GroupProperty() 
        { 
            AvailableValues = new List<GroupPropertyAvailableValues>(); 
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public List<GroupPropertyAvailableValues> AvailableValues { get; set; }
        public int Importance { get; set; }
    }
}
