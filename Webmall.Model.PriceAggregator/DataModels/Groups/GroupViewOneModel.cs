namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    public class GroupViewOneModel
    {
        /// <summary>
        /// Код группы товаров
        /// </summary>
        public int GroupId { get; set; } // GroupId (Primary key)

        /// <summary>
        /// Название группы товаров
        /// </summary>
        public string GroupName { get; set; } // GroupName (length: 100)

        /// <summary>
        /// Тип группы товаров
        /// </summary>
        public int GroupTypeId { get; set; } // GroupTypeId

        /// <summary>
        /// Называние Типа группы товаров
        /// </summary>
        public string GroupTypeName { get; set; } // GroupTypeName

        /// <summary>
        /// Примечание
        /// </summary>
        public string GroupRemark { get; set; } // GroupRemark

        /// <summary>
        /// Родительская группа товаров
        /// </summary>
        public int? GroupParentId { get; set; } // GroupParentId

        /// <summary>
        /// Имя родительской группы товаров
        /// </summary>
        public string GroupParentName { get; set; } // GroupParentName

        /// <summary>
        /// Источник данных
        /// </summary>
        public int? SourceId { get; set; } // SourceId

        /// <summary>
        /// Имя источника данных
        /// </summary>
        public string SourceName { get; set; } // SourceName
    }
}
