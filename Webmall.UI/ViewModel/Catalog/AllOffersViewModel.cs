using System.Collections.Generic;

namespace Webmall.UI.ViewModel.Catalog
{
    public class AllOffersViewModel
    {
        public OffersFilterViewModel FilterViewModel { get; set; } = new OffersFilterViewModel();
        public OffersViewModel BestOffers { get; set; }
        public List<OffersViewModel> TableOffers { get; set; } = new List<OffersViewModel>();
    }
}