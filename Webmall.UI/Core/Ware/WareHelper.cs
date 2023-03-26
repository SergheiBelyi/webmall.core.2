using System.Globalization;
using System.Linq;
using AutoMapper;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Catalog;
using Webmall.UI.ViewModel.Catalog;

namespace Webmall.UI.Core.Ware
{
    public class WareHelper : IWareHelper
    {
        private readonly IMapper _mapper;
        private const int MaxVisibleQnt = 10;

        public WareHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Offer ProcessWareOffer(Model.Entities.Catalog.Ware ware, Offer offer, OfferViewModel viewModel)
        {
            var result = _mapper.Map(offer, new Offer());
            result.AvailableQntStr = (offer.AvailableQnt.HasValue
                ? QuantityPresenter(offer.AvailableQnt.Value, false)
                : offer.AvailableQntStr) ?? "X";//SharedResources.NotAvailable;
            viewModel.InCart = (int) (SessionHelper.Cart?.Where(i => IsWareInCartPosition(ware, offer, i)).Sum(i => i.WareQnt) ?? 0);
            var rate = SessionHelper.CurrentValute.Rate;
            result.ClientPrice *= rate;
            result.RecommendedPrice *= rate;
            result.ClientSalePrice *= rate;
            return result;
        }

        public string QuantityPresenter(decimal quantity, bool showFullQuantity)
        {
            if (showFullQuantity || (quantity > 0 && quantity <= MaxVisibleQnt)) 
                return ((int)quantity).ToString(CultureInfo.InvariantCulture);
            if (quantity > MaxVisibleQnt)
                return $"> {MaxVisibleQnt}";
            return quantity == -1 ? "0" : null;
        }

        private static bool IsWareInCartPosition(Model.Entities.Catalog.Ware ware, Offer offer, CartPosition cartPos)
        {
            return offer.Id == cartPos.OfferId; // cartPos.ProducerName == ware.ProducerName && cartPos.WareNum == ware.WareNumber;
        }
    }
}