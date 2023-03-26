using System.Collections.Generic;
using ValmiStore.Model.Entities.Order;

namespace Webmall.UI.Models.Order
{
    public class DeliveryScheduleModel
    {
        // ReSharper disable InconsistentNaming
        public List<DeliverySchedule> routes { get; set; }
        public string reason { get; set; }
        // ReSharper restore InconsistentNaming
    }
}