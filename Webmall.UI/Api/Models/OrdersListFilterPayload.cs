using System;

namespace Webmall.UI.Api.Models
{
    public class OrdersListFilterPayload
    {
        public OrdersListFilterPayload()
        {
            PageSettings = new PageSettingsPayload();
        }
        
        public string OrderId { get; set; }
        public string Status { get; set; }
        public string WareName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public PageSettingsPayload PageSettings { get; set; }
    }
}