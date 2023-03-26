using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Models.Ware
{
    public class WareOffer
    {
        public WareOffer() { }

        public WareOffer(Model.Entities.Catalog.Ware ware, Offer offer) {
            Ware = ware;
            Offer = offer;
        }

        public Model.Entities.Catalog.Ware Ware;
        public Offer Offer;
        public int InCart { get; set; }

        public OfferStatuses Status(bool allowCustomOrders)
        {
            //if (IsBlocked)
            //    return OfferStatuses.Inventory;
            //if (DeliveryTerm.HasValue && ((MaxQuantity > 0 || allowCustomOrders)))
            //    return OfferStatuses.CanAddToCart;
            if (Offer.AvailableQnt > 0 || allowCustomOrders)
                return OfferStatuses.CanAddToCart;
            return OfferStatuses.Unavailable;
        }

        //public bool IsPresent => (Ware?.CanAddToCart ?? false) && Offer.Status(SessionHelper.AllowCustomOrders) == OfferStatuses.CanAddToCart;

        public string ViewPrefix => IsMobileView ? "_M" : "_D";

        public bool IsMobileView { get; set; }  = false;
    }

    public enum OfferStatuses
    {
        CanAddToCart,
        Inventory,
        Unavailable
    }
}
