namespace Webmall.Model.PriceAggregator.DataModels.Brand
{
    public class BrandViewList
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandShortName { get; set; }
        public int? BrandParentId { get; set; }
        public string BrandParentName { get; set; }
        public bool IsOur { get; set; }
        public bool IsActive { get; set; }
        public bool IsOriginal { get; set; }
    }
}
