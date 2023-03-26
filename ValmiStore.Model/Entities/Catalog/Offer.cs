using System;
using Newtonsoft.Json;

namespace Webmall.Model.Entities.Catalog
{
    public class Offer
    {
        private string _offerId;

        public string SupplierUid { get; set; }
        public bool IsTradeOrganization { get; set; }
        public string SupplierWarehouseUid { get; set; }
        public string PricelistUid { get; set; }
        /// <summary>
        /// Кратность продажи
        /// </summary>
        public int SaleQnt { get; set; }
        public decimal? AvailableQnt { get; set; }
        public string AvailableQntStr { get; set; }
        public decimal ClientPrice { get; set; }
        public decimal ClientSalePrice { get; set; }
        public decimal RecommendedPrice { get; set; }
        public int DeliveryDays { get; set; }
        public DateTime DeliveryTerm { get; set; }
        public int DeliveryRating { get; set; }
        public int ReturnDays { get; set; }
        public string SupplierWareName { get; set; }
        public string SupplierWareNumber { get; set; }
        public string SupplierBrandName { get; set; }
        public bool MyWarehouse { get; set; }
        public bool BestPrice { get; set; }
        public bool BestQnt { get; set; }
        public bool BestDelivery { get; set; }
        public bool BestReturn { get; set; }
        public string SupplierWarehouseName { get; set; }
        public bool IsBlocked { get; set; }
        public string Id
        {
            get => _offerId ?? (_offerId = $"{SupplierWareNumber}{SupplierBrandName}{SupplierUid}{SupplierWarehouseUid}{PricelistUid}{ClientPrice}").ToLower().HashSha1();
            set => _offerId = value;
        }
    }
}
