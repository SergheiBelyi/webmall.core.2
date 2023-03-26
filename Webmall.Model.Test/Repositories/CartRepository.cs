using System.Collections.Generic;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories
{
    public class CartRepository : ICartRepository
    {
        public void AddCartPosition(string culture, User user, CartPosition position)
        {
            throw new System.NotImplementedException();
        }

        public void AddCartPosition(User user, CartPosition position, string culture)
        {
            throw new System.NotImplementedException();
        }

        public void EditCommentCartPosition(User user, int id, string comment)
        {
            throw new System.NotImplementedException();
        }

        public void EditQntCartPosition(User user, CartPosition position)
        {
            throw new System.NotImplementedException();
        }

        public List<CartPosition> GetCart(string culture, User user)
        {
            throw new System.NotImplementedException();
        }

        public List<CartPosition> GetCart(string culture, User user, bool calcWarehouseQnt = false)
        {
            throw new System.NotImplementedException();
        }

        public List<CartPosition> GetCartPositionsByIdList(string culture, User user, int[] idList)
        {
            throw new System.NotImplementedException();
        }

        public List<ImportResult> ImportToCart(string clientId, int userId, string warehouseId, List<ImportPosition> importPosition)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCartPosition(User user, List<int> positions)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePosition(User user, int positionId, decimal quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}
