using System.Collections.Generic;

namespace Webmall.Model.Entities.Catalog
{
    public class WareList
    {
        public List<WareListItem> Wares { get; set; } = new List<WareListItem>();
        public int CountAllProduct { get; set; }
        public List<string> ProductGroupIdentifiers { get; set; } = new List<string>();
        public List<string> ManufacturerIdentifiers { get; set; } = new List<string>();
    }
}
