namespace Webmall.Model.PriceAggregator.DataModels.Groups
{
    public class GroupViewListModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Код группы товаров
        /// </summary>
        public int GroupId { get; set; } // GroupId (Primary key)

        /// <summary>
        /// Название группы товаров
        /// </summary>
        public string GroupName { get; set; } // GroupName (length: 100)

        /// <summary>
        /// Родительская группа товаров
        /// </summary>
        public int? GroupParentId { get; set; } // GroupParentId
    }
}
