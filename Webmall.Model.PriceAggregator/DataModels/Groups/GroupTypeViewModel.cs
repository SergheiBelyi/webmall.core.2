namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    // GroupType
    /// <summary>
    /// Типы групп товаров
    /// </summary>
    public class GroupTypeViewModel
    {
        /// <summary>
        /// Код типа группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId (Primary key)

        /// <summary>
        /// название типа группы товаров
        /// </summary>
        public string GroupTypeName { get; set; } // GroupTypeName (length: 100)

        /// <summary>
        /// Примечание
        /// </summary>
        public string GroupTypeRemark { get; set; } // GroupTypeRemark

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId
    }
}
