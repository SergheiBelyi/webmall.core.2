using System;
using System.Collections.Generic;
using PriceAggregator.Domain.Common;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные кузова для автомобиля
    /// </summary>
    public class AutoYears : BaseReference<string, string>
    {
        /// <summary>
        /// Дата начала выпуска
        /// </summary>
        public DateTime? DateBegin { get; set; }

        /// <summary>
        /// Дата окончания выпуска
        /// </summary>
        public DateTime? DateEnd { get; set; }
    }

    public class AutoYearsEqualityComparer : IEqualityComparer<AutoYears>
    {
        public bool Equals(AutoYears x, AutoYears y) => x.DateBegin == y.DateBegin && x.DateEnd == y.DateEnd;

        public int GetHashCode(AutoYears obj) => (obj.DateBegin.ToString()+obj.DateEnd).GetHashCode();
    }
}
