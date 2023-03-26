using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Data for Auto model detail
    /// </summary>
    public class AutoModelDetail
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Сокращенное наименование (Полное без сокращенного с начала)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сокращенное наименование
        /// </summary>
        public string ShortName { get; set; }

        public string ModelId { get; set; }

        /// <summary>
        /// Наименование для модели
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Дата начала выпуска
        /// </summary>
        public DateTime? DateBegin { get; set; }

        /// <summary>
        /// Дата окончания выпуска
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        /// Год начала выпуска
        /// </summary>
        public int? YearBegin => DateBegin?.Year;

        /// <summary>
        /// Год окончания выпуска
        /// </summary>
        public int? YearEnd => DateEnd?.Year;

        public IList<AutoModificationData> Modifications { get; set; }
    }
}
