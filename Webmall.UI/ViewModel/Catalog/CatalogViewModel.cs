using System.Collections.Generic;
using Webmall.Model.Entities.Auto;
using Webmall.UI.Models.Catalog;
using Webmall.UI.Models.SelectionByAuto;

namespace Webmall.UI.ViewModel.Catalog
{
    public class CatalogViewModel
    {
        //public CatalogPropertiesModel CatalogPropertiesModel { get; set; } = new CatalogPropertiesModel();
        public CatalogFilterViewModel CatalogFilterViewModel { get; set; }
        public CatalogWaresModel WaresCatalog { get; set; }
        public string Title { get; set; }
        public int ViewMode { get; set; }
        public AutoModification AutoModification { get; set; }
        public SelectionByAutoMarkModel SelectionByAutoMarkModel { get; set; } = new SelectionByAutoMarkModel();
        public List<BreadCrumbsModel> BreadCrumbs { get; set; }

        //public bool ShowGroupIcons => WaresCatalog?.CurrentGroup?.HasSubGroups == true && AutoModification == null;
        //public bool ShowWaresList => WaresCatalog?.Wares != null && (WaresCatalog.ShowAllWares == true || !ShowGroupIcons || WaresCatalog.Wares.List.Any());
    }
}