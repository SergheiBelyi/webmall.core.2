using System.Collections.Generic;
using ValmiStore.Model.Entities;
using Webmall.UI.Models.Catalog;

namespace Webmall.UI.Models.SelectionByAuto
{
    public class TiresSelectionModel
    {
        public string GroupId { get; set; }
        public int TypeParameter { get; set; }
        public string[] TypeValues { get; set; }
        public int SeasonParameter { get; set; }
        public string[] SeasonValues { get; set; }

        public int WidthParameter { get; set; }
        public int HeightParameter { get; set; }
        public int DiameterParameter { get; set; }

        public int Season { get; set; }

        public List<TiresCombination> TiresCombinations { get; set; }
    }
}