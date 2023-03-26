
using System.Collections.Generic;
using ValmiStore.Model.Entities;

namespace Webmall.UI.Models.Ware
{
    public class WareCard
    {
        public string Url;
        public string Id;
        public string IdNorm;
        public string ImgUrl;
        public string Name;
        public string ProducerName;
        public string PartNumber;

        /// <summary>
        /// Unit of measure
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string UOM;

        public string Price;
        public string RetailPrice;

        public string OfferId;
        public string OfferTypeId;
        public string ValuteName;
        public string InStockQty;

        public bool CanAddToCart;
        public bool OnlyForReservation;
        public List<Offer> Offers;
        internal int? SaleMultiplier;

        public bool IsPresent;
        public bool ShowAction;
        public bool IsSale;
        public bool IsAction;
        public bool OnePrice;
        public int? DiscGroupTypeId;
        public string CurrentWarehouseId;
        public bool IsNew;
        public bool LoadAnalogues;
        public int InCart { get; set; }
        public List<Sticker> Stickers { get; set; } = new List<Sticker>();
    }
}