using System.Collections.Generic;

namespace Webmall.UI.Models.Cart
{
    public class WareAnalogsModel
    {
        public WareAnalogsModel()
        {
            WaresAnalogs = new List<int>();
        }

        public List<ValmiStore.Model.Entities.Ware> Wares { get; set; }
        public List<int> WaresAnalogs { get; set; }
    }
}