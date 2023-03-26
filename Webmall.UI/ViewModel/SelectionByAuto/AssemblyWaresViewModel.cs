using System.Collections.Generic;
using Webmall.Model.Entities.Catalog;
using Webmall.UI.Models.Catalog;
using Webmall.UI.Models.SelectionByAuto;

namespace Webmall.UI.ViewModel.SelectionByAuto
{
    public class AssemblyWaresViewModel
    {
        public CatalogWaresModel WaresModel { get; set; }

        public List<WareListItem> Items { get; set; }

        public AutoGroupTree Assembly { get; set; }
    }
}