using System.Collections.Generic;
using Webmall.Model.Entities.Order;

namespace Webmall.UI.ViewModel.Order
{
    public class OrdersDetailModel
    {
        public Model.Entities.Order.Order Order { get; set; }
        //public List<RefOrderStatus> Statuses;
        public List<RefOrderStatus> PositionStatuses;
        public string ValuteName;
    }
}