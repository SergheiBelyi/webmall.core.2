using System.Collections.Generic;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.ViewModel.Catalog
{
    public class WareCardViewModel
    {
        //public CatalogPropertiesModel CatalogPropertiesModel { get; set; } = new CatalogPropertiesModel();
        //public OffersFilterViewModel FilterViewModel { get; set; } = new OffersFilterViewModel();

        public FilterOptions FilterOptions { get; set; }

        public Ware Ware { get; set; }

        public List<BreadCrumbsModel> BreadCrumbs { get; set; }

        //public List<Offer> Offers { get; set; }
        //public List<WareReplacements> Replacements { get; set; }
    }
}