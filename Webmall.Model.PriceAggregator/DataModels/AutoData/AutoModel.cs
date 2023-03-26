using System;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Data for Auto model
    /// </summary>
    public class AutoModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        public string Uid { get; set; }

        public int MarkaId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Короткое наименование
        /// </summary>
        public string ShortName { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Дата начала выпуска
        /// </summary>
        public DateTime? DateBegin { get; set; }

        /// <summary>
        /// Дата окончания выпуска
        /// </summary>
        public DateTime? DateEnd { get; set; }

    }

}
