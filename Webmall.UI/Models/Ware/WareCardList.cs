using System.Collections.Generic;

namespace Webmall.UI.Models.Ware
{
    public class WareCardList : List<WareCard>
    {
        public bool AreAnalogues { get; set; }
        public bool InTab { get; set; }
        public bool CanAddToCart;
        public bool AllowCustomOrders;
    }
}
