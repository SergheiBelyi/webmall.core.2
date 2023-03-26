using Webmall.Model.Entities.Catalog;
using Webmall.UI.ViewModel.Catalog;

namespace Webmall.UI.Core.Ware
{
    public interface IWareHelper
    {
        Offer ProcessWareOffer(Model.Entities.Catalog.Ware ware, Offer offer, OfferViewModel viewModel);

        string QuantityPresenter(decimal quantity, bool showFullQuantity);
    }
}
