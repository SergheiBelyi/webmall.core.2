using System.Collections.Generic;
using Webmall.Model.Entities.Cart;

namespace Webmall.UI.Models.Cart
{
    public class OrderPreviewModel
    {
        public string Term { get; set; }
        public IEnumerable<CartPosition> Positions { get; set; }
    }
}