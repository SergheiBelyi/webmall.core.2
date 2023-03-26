using System;
using System.Collections.Generic;
using AutoMapper;
using log4net;
using log4net.Config;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Cart;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.Model.Entities.User;
using Webmall.Model.ERP_1C.Connect1C;
using Webmall.Model.ERP_1C.ERP_1C_ServiceReference;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.ERP_1C.Repositories
{
    class CartRepository : ICartRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(CartRepository));

        static CartRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly TW_SiteIntegrationPortTypeClient _erpClient;
        private readonly IMapper _mapper;

        public CartRepository(TW_SiteIntegrationPortTypeClient erpClient, IMapper mapper)
        {
            _erpClient = erpClient;
            _mapper = mapper;
        }

        public void AddCartPosition(User user, CartPosition position, string culture)
        {
            throw new NotImplementedException();
        }

        public void EditCommentCartPosition(User user, int id, string comment)
        {
            throw new NotImplementedException();
        }

        public void EditQntCartPosition(User user, CartPosition position)
        {
            throw new NotImplementedException();
        }

        public List<CartPosition> GetCart(string culture, User user, bool calcWarehouseQnt = false)
        {
            /*var response = _erpClient.GetCart(calcWarehouseQnt, user.CurrentClientId, culture, user.Id);
            List<CartPosition> result = ResponseFrom1C<List<CartPosition>>.Get(response, nameof(_erpClient.GetClientAgreements));*/

            return new List<CartPosition>();
            //throw new NotImplementedException();
        }

        public List<CartPosition> GetCartPositionsByIdList(string culture, User user, int[] idList)
        {
            throw new NotImplementedException();
        }

        public List<ImportResult> ImportToCart(string clientId, int userId, string warehouseId, List<ImportPosition> importPosition)
        {
            throw new NotImplementedException();
        }

        public void RemoveCartPosition(User user, List<int> positions)
        {
            throw new NotImplementedException();
        }

        public void UpdatePosition(User user, int positionId, decimal quantity)
        {
            throw new NotImplementedException();
        }
    }
}
