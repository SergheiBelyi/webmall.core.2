using Webmall.Model.Entities.Cart;
using Webmall.UI.Core;

namespace Webmall.UI.Models.Cart
{
    public class CartModel
    {
        public CartModel()
        {
            Positions = new GridViewModel<CartPosition>();
            InOrderId = null;
        }

        public CartModel(string inOrderId)
        {
            Positions = new GridViewModel<CartPosition>();
            InOrderId = inOrderId;
        }

        public GridViewModel<CartPosition> Positions { get; set; }
        public string InOrderId { get; set; }
        public string ValuteName { get; set; }
    }
}