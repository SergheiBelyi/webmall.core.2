namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AutoModifsFilter
    {
        /// <summary>
        /// Идентификатор модификации в ПА
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Uid модификации
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Идентификатор модели в ПА
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Uid модели в ПА
        /// </summary>
        public string ModelUid { get; set; }

        /// <summary>
        /// Наименование модификации
        /// </summary>
        public string Name { get; set; }
    }
}
