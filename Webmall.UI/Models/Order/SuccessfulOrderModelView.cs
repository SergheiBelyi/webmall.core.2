using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Cms.Order;
using Webmall.Model.Entities.Order;

namespace Webmall.UI.Models.Order
{
    public class SuccessfulOrderModelView
    {
        public string OrderId { get; set; }
        public DateTime DataCreateOrder { get; set; }
        public string StatusOrder { get; set; }
        public string AuthorOrder { get; set; }
        public List<OrderPosition> Positions { get; set; }

        public decimal? TotalPrice { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
        public string DeliveryType { get; set; }
        public string DeliveryAddress { get; set; }

        public string TotalQnt { get; set; }
        public string ValuteName { get; set; }

        public SuccessfulText SuccessPageText { get; set; }
    }
}