using System.Collections.Generic;
using System.Web.Mvc;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.Cms.Order;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.UI.Core;

namespace Webmall.UI.Models.Order
{
    public class CreateOrderModelView
    {
        public CreateOrderModelView()
        {
            Positions = new List<CartPosition>();
        }

        public string ClientId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

        public List<CartPosition> Positions { get; set; }

        public string Comment { get; set; }
        public bool NeedToCheck { get; set; }

        /*public CheckoutDeliveryData Delivery { get; set; }
        public CheckoutPaymentData Payment { get; set; }*/

        public string ValuteName { get; set; }
        public List<OrderPayment> OrderPayment { get; set; }

        public EmbeddedText InfoAdditional { get; set; }
        public EmbeddedText InfoDelivery { get; set; }
        public EmbeddedText InfoPayment { get; set; }
        public EmbeddedText InfoAttention { get; set; }

        public decimal? TotalPrice { get; set; }
        public string TotalQnt { get; set; }

        public List<SelectListItem> Contacts { get; set; }
        public List<SelectListItem> PickupPoints { get; set; }
        public string WarehouseId { get; set; }

    }
}