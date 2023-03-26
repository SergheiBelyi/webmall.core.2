using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using log4net;
using log4net.Config;
using Webmall.Model.Database.DataLayer;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Database.Repositories
{
    public class CartRepository : ICartRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepository));

        static CartRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        readonly WebmallDbContext _db = new WebmallDbContext();
        private readonly IMapper _mapper;

        public CartRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        ~CartRepository()
        {
            try
            {
                _db.Dispose();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public List<CartPosition> GetCart(string culture, User user, bool calcWarehouseQnt = false)
        {
            if (user == null)
                return null;
            var query = PrepareCartQuery(user);
            return _mapper.Map<List<CartPosition>>(query);
        }

        public List<CartPosition> GetCartPositionsByIdList(string culture, User user, int[] idList)
        {
            var query = PrepareCartQuery(user).Where(i => idList.Contains(i.Id));

            return _mapper.Map<List<CartPosition>>(query);
        }

        public void AddCartPosition(User user, CartPosition position, string culture)
        {
            if (user == null)
                return;
            _db.Cart.Add(_mapper.Map<DbCartPosition>(position));
            _db.SaveChanges();
        }

        public void RemoveCartPosition(User user, List<int> positions)
        {
            if (user == null)
                return;
            var query = PrepareCartQuery(user).Where(i => positions.Contains(i.Id));

            var itemsToRemove = query.ToArray();

            _db.Cart.RemoveRange(itemsToRemove);
            _db.SaveChanges();
        }

        public void EditCommentCartPosition(User user, int id, string comment)
        {
            var dbPos = _db.Cart.FirstOrDefault(i => i.Id == id);
            dbPos.Comment = comment;

            _db.SaveChanges();
        }

        public void EditQntCartPosition(User user, CartPosition position)
        {
            var dbPos = _db.Cart.FirstOrDefault(i => i.Id == position.Id);
            dbPos.WareQnt = position.WareQnt;

            _db.SaveChanges();
        }

        public List<ImportResult> ImportToCart(string clientId, int userId, string warehouseId, List<ImportPosition> importPosition)
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(User user, int positionId, decimal quantity)
        {
            if (user == null)
                return;
            var position = PrepareCartQuery(user).FirstOrDefault(i => positionId == i.Id);
            if (position != null)
            {
                position.WareQnt = quantity;
                _db.SaveChanges();
            }
        }

        private IQueryable<DbCartPosition> PrepareCartQuery(User user)
        {
            var query = _db.Cart.Where(i => i.ClientId == user.CurrentClientId);

            if (!user.CurrentPresenter.CanSeeAllCart)
            {
                query = query.Where(i => i.UserId == user.Id);
            }

            return query;
        }
    }
}
