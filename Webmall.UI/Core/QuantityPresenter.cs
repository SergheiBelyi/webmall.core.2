using ValmiStore.Model.Entities;
using Webmall.Model;

public class QuantityPresenter
{
    private readonly bool alwaysShowFullAmount;

    public QuantityPresenter(bool showFull)
    {
        alwaysShowFullAmount = showFull;
    }

    public string OfferQnt(Offer offer)
    {
        string result;
        switch (offer.OfferTypeId)
        {
            case null:
                result = "";
                break;
            case 6:
            case 1:
                result = Helper.QuantityPresenter(offer.MaxQuantity, alwaysShowFullAmount);
                break;
            case 2:
                result = offer.MaxQuantity > 1 ? Helper.QuantityPresenter(offer.MaxQuantity, alwaysShowFullAmount) : ((int)(offer.MaxQuantity ?? 0)).ToString();
                break;
            default:
                result = "> 10";
                break;
        }
        return result;
    }


    public string ShippingStockQnt(Offer offer)
    {
       return offer.OfferTypeId > 3 ? "-" : (offer.MaxQuantity > 0) ? 
            Helper.QuantityDigitalPresenter(offer.ShippingStockQnt, alwaysShowFullAmount) : 
            Helper.QuantityPresenter(offer.ShippingStockQnt, alwaysShowFullAmount);
    }

    /// <summary>
    /// Кол-во на складе (для показа)
    /// </summary>
    public string WareQnt(Ware ware)
    {
        return (ware.Offer != null && ware.Offer.OfferTypeId > 1) ? "-" :
            ware.IsSale ? GetWareQntForDisplay(ware.SaleQnt, ware.SaleQnt) : GetWareQntForDisplay(ware.WareQnt, ware.WareQntTotal);
    }

    private string GetWareQntForDisplay(decimal? localQnt, decimal? globalQnt)
    {
        return globalQnt > 0 ? Helper.QuantityDigitalPresenter(localQnt, alwaysShowFullAmount) :
                Helper.QuantityPresenter(localQnt, alwaysShowFullAmount);
    }

    /// <summary>
    /// Кол-во на всех складах (для показа)
    /// </summary>
    public string WareQntTotal(Ware ware)
    {
        return Helper.QuantityPresenter((ware.WareQntTotal ?? 0)+(ware.SaleQnt??0), alwaysShowFullAmount);
    }
}