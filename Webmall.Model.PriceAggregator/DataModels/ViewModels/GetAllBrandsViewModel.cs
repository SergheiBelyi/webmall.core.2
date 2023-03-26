namespace SERP.Product.Api.Domain.Models.ViewModels
{
    public class GetAllBrandsViewModel
    {
        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; } // BrandId (Primary key)

        /// <summary>
        /// Название бренда
        /// </summary>
        public string BrandName { get; set; } // BrandName (length: 100)
    }
}
