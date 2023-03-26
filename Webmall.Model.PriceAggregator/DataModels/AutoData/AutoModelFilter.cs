namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AutoModelFilter
    {
        /// <summary>
        /// Идентификатор модели в ПА
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Uid модели
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Идентификатор марки в ПА
        /// </summary>
        public int? MarkaId { get; set; }

        /// <summary>
        /// Uid марки в ПА
        /// </summary>
        public string MarkaUid { get; set; }

        /// <summary>
        /// Наименование модели
        /// </summary>
        public string Name { get; set; }
    }
}
