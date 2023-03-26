namespace Webmall.UI.Models.Ware
{
    public class AnalogsModel
    {
        public bool HasImage { get; set; }
        public string WareId { get; set; }
        public string WareNumber { get; set; }
        public string WareName { get; set; }
        public string WareProducer { get; set; }
        public string AvailableQnty { get; set; }
        public string ShippingStockQnt { get; set; }
        public string Delivery { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public string OfferId { get; set; }
        public int? OfferTypeId { get; set; }
        public int Warranty { get; set; }
        public bool IsOriginal { get; set; }
        public int? MainImageCode { get; set; }
        public string AdditionalInfo { get; set; }
        public string ActionInfo { get; set; }
    }
}