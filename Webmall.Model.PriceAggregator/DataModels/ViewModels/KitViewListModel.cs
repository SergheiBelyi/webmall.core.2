namespace SERP.Product.Api.Domain.Models.ViewModels
{
    public class KitViewListModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int KitId { get; set; }

        /// <summary>
        /// Товар-комплект
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Товар-комплектующий
        /// </summary>
        public int ComponentId { get; set; }

        /// <summary>
        /// ​Каталожный номер товара-комплектующего
        /// </summary>
        public string ComponentCode { get; set; }
        
        /// <summary>
        /// ​Каталожный номер товара-комплектующего
        /// </summary>
        public string Component​BrandName { get; set; }

        /// <summary>
        /// ​Наименование товара-комплектующего на языке
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// ​Кол-во товара-комплектующего в комплекте
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Единица измерений для комплектующего
        /// </summary>
        public string UnitShortName { get; set; }

        /// <summary>
        /// Единица измерений для комплектующего
        /// </summary>
        public int UnitId { get; set; }
    }
}
