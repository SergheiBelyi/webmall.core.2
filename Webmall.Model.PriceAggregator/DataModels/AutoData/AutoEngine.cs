using System.Collections.Generic;
using PriceAggregator.Domain.Common;

namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Данные двигателя для автомобиля
    /// </summary>
    public class AutoEngine : BaseReference<string, string>
    {
    }

    public class AutoEngineEqualityComparer : IEqualityComparer<AutoEngine>
    {

        public bool Equals(AutoEngine x, AutoEngine y) => x.Id == y.Id;

        public int GetHashCode(AutoEngine obj) => obj.Id.GetHashCode();
    }
}
