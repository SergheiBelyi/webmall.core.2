namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    public class GroupProductLinkViewList
    {
        /// <summary>
        /// Идентификатор связи
        /// </summary>
        public int GroupProductLinkId { get; set; } // GroupProductLinkId (Primary key)

        /// <summary>
        /// Группа товаров
        /// </summary>
        public int GroupId { get; set; } // GroupId

        /// <summary>
        /// Название группы товаров
        /// </summary>
        public string GroupName { get; set; } // GroupName (length: 100)

        /// <summary>
        /// Код бренда
        /// </summary>
        public int BrandId { get; set; } // BrandId (Primary key)

        /// <summary>
        /// Название бренда
        /// </summary>
        public string BrandName { get; set; } // BrandName (length: 100)

        /// <summary>
        /// Товар
        /// </summary>
        public int ProductId { get; set; } // ProductId

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string ProductCode { get; set; } // ProductCode (length: 50)

        /// <summary>
        /// Тип группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId

        /// <summary>
        /// название типа группы товаров
        /// </summary>
        public string GroupTypeName { get; set; } // GroupTypeName (length: 100)
    }
}
