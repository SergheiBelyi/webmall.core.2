using System.Collections.Generic;
using Webmall.Model.Entities.Order;
using Webmall.UI.Core;

namespace Webmall.UI.ViewModel.Order
{
    public class OrderLinesListViewModel
    {
        public OrderLinesListViewModel()
        {
            Orders = new GridViewModel<OrderPositionsListItem>();
        }

        public GridViewModel<OrderPositionsListItem> Orders { get; set; }
        public List<RefOrderStatus> PosStatuses { get; set; }
        public List<RefOrderStatus> Statuses { get; set; }
        public OrdersFilterViewModel Filters = new OrdersFilterViewModel();
    }
}