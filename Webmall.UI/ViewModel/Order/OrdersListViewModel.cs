using System.Collections.Generic;
using Webmall.Model.Entities.Order;
using Webmall.UI.Core;

namespace Webmall.UI.ViewModel.Order
{
    public class OrdersListViewModel
    {
        public GridViewModel<OrderListItem> Orders { get; set; } = new GridViewModel<OrderListItem>();
        public List<RefOrderStatus> Statuses { get; set; }
        public List<RefOrderStatus> PosStatuses { get; set; }
        public OrdersFilterViewModel Filters { get; set; } = new OrdersFilterViewModel();
    }
}