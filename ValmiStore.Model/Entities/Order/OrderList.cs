using System.Collections.Generic;

namespace Webmall.Model.Entities.Order
{
    public class OrderList
    {
        public List<OrderListItem> List { get; set; } = new List<OrderListItem>();
        public int Total { get; set; }
    }
}