using PriceAggregator.Domain.Common;
using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные кузова для автомобиля
    /// </summary>
    public class AutoBody : BaseReference<string, string>
    {
        /// <summary>
        /// ImageUrl
        /// </summary>
        public string ImageUrl { get; set; }
    }

    public class AutoBodyEqualityComparer : IEqualityComparer<AutoBody>
    {

        public bool Equals(AutoBody x, AutoBody y) => x.Id == y.Id;

        public int GetHashCode(AutoBody obj) => obj.Id.GetHashCode();
    }
}
