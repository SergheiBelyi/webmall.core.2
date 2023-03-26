namespace Webmall.Model.Entities.Catalog
{
    public class WareListItem
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string ProducerId { get; set; }
        public string ProducerName { get; set; }
        public Producer Producer { get; set; }
        public string WareNumber { get; set; }
        public string Name { get; set; }
        public bool HasImage { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool InComplect { get; set; }
        public string MeasureUnit { get; set; }
        public decimal MinimalPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public int Qnt { get; set; }
        public string Availability { get; set; }
        public bool IsAction { get; set; }
        public bool IsSale { get; set; }
        public bool IsNew { get; set; }
        public bool IsOriginal { get; set; }
    }
}
