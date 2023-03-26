using System.Collections.Generic;
using Webmall.Model.Entities.Catalog;

namespace Webmall.Model.PriceAggregator.DataModels
{
    public class WareListModel
    {
        public WareListModel()
        {
            Wares = new List<WareListItem>();
            Brands = new List<GroupPropertyAvailableValues>();
        }
        public List<WareListItem> Wares { get; set; }
        public int FoundRows { get; set; }
        public List<GroupPropertyAvailableValues> Brands { get; set; }
    }
}
