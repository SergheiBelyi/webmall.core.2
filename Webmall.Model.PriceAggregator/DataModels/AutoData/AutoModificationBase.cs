using System;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    public class AutoModificationBase
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        public string Uid { get; set; }

        /// <summary>
        /// Идентификатор модели
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата начала выпуска
        /// </summary>
        public DateTime? DateBegin { get; set; }

        /// <summary>
        /// Дата окончания выпуска
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Мощность, л.с.
        /// </summary>
        public int? PS { get; set; }

        /// <summary>
        /// Объем, куб.см
        /// </summary>
        public int? ccmTech { get; set; }
    }
}