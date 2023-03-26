using System.Collections.Generic;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Client;

namespace Webmall.UI.ViewModel.Catalog
{
    public class OffersViewModel
    {
        public Valute Valute { get; set; }
        public string PriceFormat { get; set; } = "n2";
        public string Caption { get; set; }
        public List<OfferViewModel> Offers { get; set; } = new List<OfferViewModel>();
        public PageOptions PageOptions { get; set; }
    }
}