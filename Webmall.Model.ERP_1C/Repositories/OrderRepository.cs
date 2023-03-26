using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using log4net;
using log4net.Config;
using Webmall.Model.CoreHelpers;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.Model.Entities.User;
using Webmall.Model.ERP_1C.Connect1C;
using Webmall.Model.ERP_1C.ERP_1C_ServiceReference;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.ERP_1C.Repositories
{
    class OrderRepository : IOrderRepository
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(ClientRepository));

        static OrderRepository()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private readonly TW_SiteIntegrationPortTypeClient _erpClient;
        private readonly IMapper _mapper;

        public OrderRepository(TW_SiteIntegrationPortTypeClient erpClient, IMapper mapper)
        {
            _erpClient = erpClient;
            _mapper = mapper;
        }

        private static readonly object GetOrderStatusesLock = new object();
        public List<RefOrderStatus> GetOrderStatuses(string culture)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + culture;
            var list = HttpRuntime.Cache.Get(key, GetOrderStatusesLock, () =>
            {

                    var response = _erpClient.GetOrderStatuses(culture);
                    List<RefOrderStatus> result = ResponseFrom1C<List<RefOrderStatus>>.Get(response, nameof(_erpClient.GetOrderStatuses));
                    foreach (var item in result.Where(i=>i.Color == 0))
                    {
                        item.Color = 0xFFFFFF;
                    }
                    return result;
            });
            return list;
        }

        private static readonly object GetOrderPositionStatusesLock = new object();
        public List<RefOrderStatus> GetOrderPositionStatuses(string culture)
        {
            var key = MethodBase.GetCurrentMethod()?.Name + culture;
            var list = HttpRuntime.Cache.Get(key, GetOrderPositionStatusesLock, () =>
            {

                var response = _erpClient.GetOrderPositionStatuses(culture);
                List<RefOrderStatus> result = ResponseFrom1C<List<RefOrderStatus>>.Get(response, nameof(_erpClient.GetOrderPositionStatuses));
                foreach (var item in result.Where(i => i.Color == 0))
                {
                    item.Color = 0xFFFFFF;
                }
                return result;
            });
            return list;
        }
        public OrderList GetOrderList(string clientId, OrderFilterOptions filter, PageOptions options)
        {
            Log.Debug($"GetOrderList: ClientId: {clientId}, OrderFilter: {filter.ToJson()}, PageOptions: {options.ToJson()}");
            var response = _erpClient.GetOrderList(clientId, null, filter.ToJson(), options.ToJson());
            OrderList result = ResponseFrom1C<OrderList>.Get(response, nameof(_erpClient.GetOrderList));
            if (result != null)
                foreach (var item in result.List)
                    item.Id = item.Number;

            return result ?? new OrderList();
        }

        public List<OrderListItem> GetPublicOrderList(string locale, string warehouseId)
        {
            throw new NotImplementedException();
        }

        public OrderPositionsList GetOrderPositionsList(string clientId, OrderFilterOptions filter, PageOptions options)
        {
            Log.Debug($"GetOrderPositionsList: ClientId: {clientId}, OrderFilter: {filter.ToJson()}, PageOptions: {options.ToJson()}");
            var response = _erpClient.GetOrderPositionsList(clientId, null, filter.ToJson(), options.ToJson());
            OrderPositionsList result = ResponseFrom1C<OrderPositionsList>.Get(response, nameof(_erpClient.GetOrderPositionsList));
            return result ?? new OrderPositionsList();
        }

        public Order GetOrder(string locale, string clientId, string orderId, bool onlyHeader = false)
        {
            var response = _erpClient.GetOrder(clientId, locale, onlyHeader, orderId);
            Order result = ResponseFrom1C<Order>.Get(response, nameof(_erpClient.GetOrder));
            return result;
        }

        public string CreateOrder(CheckoutOrderData orderData)
        {
            var testPayment = _erpClient.GetPaymentForms("ru-RU");
            //var result = _erpClient.CreateOrder(testJson);

            var jsonData = orderData.ToJson();
            Log.Debug(jsonData);
            var response = _erpClient.CreateOrder(jsonData);
            string result = ResponseFrom1C<string>.Get(response, nameof(_erpClient.CreateOrder));

            return result;
        }

        public string SetOrderDelivery(SetOrderDeliveryData deliveryData)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(User user, string id)
        {
            throw new NotImplementedException();
        }

        public List<OrderPosition> GetOrderPositions(string locale, string clientId, string orderId)
        {
            Log.Debug($"GetOrderPositions: ClientId: {clientId}, orderId: {orderId}");
            var response = GetOrder(locale, clientId, orderId);
            return response.Positions;
        }

        public string DuplicateOrder(User user, string orderId)
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadOrderCard(string clientId, string orderId, string type)
        {
            throw new NotImplementedException();
        }

        public List<PickupPointInfo> GetPickupPoints(string cityId, string clientId)
        {
            /*var response = _erpClient.GetPickupPoints(cityId, clientId);
            List<PickupPointInfo> result = ResponseFrom1C<List<PickupPointInfo>>.Get(response, nameof(_erpClient.GetPickupPoints));
            return result;*/

             return new List<PickupPointInfo>
            {
                new PickupPointInfo
                {
                    Id = "1",
                    Name = "Test1",
                    MaxWeight = 1,
                    Schedule = "Schedule test 1",
                    Comment = "Comment test 1",
                    CanTakeMoney = true
                },
                new PickupPointInfo
                {
                    Id = "2",
                    Name = "Test2",
                    MaxWeight = 2,
                    Schedule = "Schedule test 2",
                    Comment = "Comment test 2",
                    CanTakeMoney = false
                }
            };
        }

    }
}
