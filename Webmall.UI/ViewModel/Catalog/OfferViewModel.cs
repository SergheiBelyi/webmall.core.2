using Webmall.Model.Entities.Catalog;
using Webmall.UI.Core;

namespace Webmall.UI.ViewModel.Catalog
{
    public class OfferViewModel
    {
        public bool IsReplacement { get; set; }
        public string Caption { get; set; }
        public Ware Ware { get; set; }
        public Offer Offer { get; set; }
        public int InCart { get; set; }
        public bool AllowAddToCompare { get; set; }
        public bool IsInCompare { get; set; }
        public OfferStatuses Status
        {
            get
            {
                //if (IsBlocked)
                //    return OfferStatuses.Inventory;
                //if (DeliveryTerm.HasValue && ((MaxQuantity > 0 || allowCustomOrders)))
                //    return OfferStatuses.CanAddToCart;
                if (Offer.AvailableQnt > 0 || SessionHelper.AllowCustomOrders)
                    return OfferStatuses.CanAddToCart;
                return OfferStatuses.Unavailable;
            }
        }
    }
    public enum OfferStatuses
    {
        CanAddToCart,
        Inventory,
        Unavailable
    }
}