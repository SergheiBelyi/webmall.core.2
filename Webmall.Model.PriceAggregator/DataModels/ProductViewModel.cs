namespace SERP.Product.Api.Domain.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductBaseName { get; set; }
        public int UnitId { get; set; }
        public string UnitShortName { get; set; }
    }
}
