using System.Collections.Generic;

namespace PriceAggregator.Domain.Common
{
    /// <summary>
    /// Базовый справочник
    /// </summary>
    public class BaseReference <TId, TValue>
    {
        public BaseReference()
        {
        }

        public BaseReference(TId id, TValue value)
        {
            Id = id;
            Value = value;
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public TValue Value { get; set; }
    }

    public class BaseReferenceEqualityComparer<TId, TValue> : IEqualityComparer<BaseReference<TId, TValue>>
    {
        public bool Equals(BaseReference<TId, TValue> x, BaseReference<TId, TValue> y) => x.Id.Equals(y.Id);

        public int GetHashCode(BaseReference<TId, TValue> obj) => obj.Id.GetHashCode();
    }
}
