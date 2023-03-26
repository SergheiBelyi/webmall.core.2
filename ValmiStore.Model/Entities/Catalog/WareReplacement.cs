using System.Collections.Generic;

namespace Webmall.Model.Entities.Catalog
{
    public class WareReplacement : Offer
    {
        public WareListItem Ware { get; set; }
        public List<WareProperty> Properties { get; set; }
    }
}
