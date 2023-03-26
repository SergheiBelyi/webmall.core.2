using System.Collections.Generic;
using ValmiStore.Model.Entities;

namespace Webmall.Model.CoreHelpers
{
    public class WareComparer : IEqualityComparer<Ware>
    {
        public int Compare(Ware x, Ware y)
        {
            return string.CompareOrdinal(x.WareNum + x.ProducerName, y.WareNum + y.ProducerName);
        }

        public bool Equals(Ware x, Ware y)
        {
            if (x == null || y == null)
                return false;
            return Equals(x.WareNum + x.ProducerName, y.WareNum + y.ProducerName);
        }

        public int GetHashCode(Ware obj)
        {
            return (obj.WareNum + obj.ProducerName).GetHashCode();
        }
    }
}
