using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;

namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    public class GroupPropertyModel
    {
        public GroupPropertyModel()
        {
            AvailableValues = new List<GroupPropertyAvailableValues>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GroupPropertyAvailableValues> AvailableValues { get; set; }
        public int Importance { get; set; }
    }
}
