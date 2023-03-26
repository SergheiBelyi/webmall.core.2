using System.Collections.Generic;
using Webmall.Model.Entities.Order;

namespace Webmall.UI.ViewModel.Order
{
    public class OrdersFilterViewModel
    {
        public List<RefOrderStatus> Statuses;
        public bool AutoSubmit { get; set; } = false;
        public OrderFilterOptions FilterOptions {get; set; }
    }
}