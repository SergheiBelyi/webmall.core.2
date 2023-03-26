using System.Collections.Generic;

namespace Webmall.Model.Entities.Order
{
    public class OrderPositionsList
    {
        public List<OrderPositionsListItem> List { get; set; }
        public int Total { get; set; }
    }
}