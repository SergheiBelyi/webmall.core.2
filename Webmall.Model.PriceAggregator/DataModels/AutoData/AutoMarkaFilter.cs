using System;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AutoMarkaFilter
    {
        /// <summary>
        /// Идентификатор марки в ПА
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Uid марки
        /// </summary>
        public string Uid { get; set; }

        /// <summary>
        /// Наименование марки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        public DateTime? UpdatedAfter { get; set; }
    }
}
