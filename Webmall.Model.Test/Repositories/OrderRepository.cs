using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Delivery;
using Webmall.Model.Entities.Order;
using Webmall.Model.Entities.Order.Checkout;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.Model.Test.Repositories.TestData;

namespace Webmall.Model.Test.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderTestData _testData;
        public static string DateFormat { get; set; } = "dd.MM.yyyy"; //CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        public OrderRepository()
        {
            _testData = new OrderTestData();
        }

        public List<RefOrderStatus> GetOrderStatuses(string locale)
        {
            return _testData.OrderStatuses;
        }

        public List<RefOrderStatus> GetOrderPositionStatuses(string locale)
        {
            return _testData.OrderPositionStatuses;
        }

        public List<OrderPosition> GetOrderPositions(string locale, string clientId, string orderId)
        {
            var list = _testData.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(orderId))
                list = list.Where(i => i.Id.Equals(orderId));

            return list.FirstOrDefault()?.Positions ?? new List<OrderPosition>();
        }

        public OrderList GetOrderList(string clientId, OrderFilterOptions filterOptions, PageOptions pageOptions)
        {
            var list = _testData.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(filterOptions.OrderId))
                list = list.Where(i => i.Number.Contains(filterOptions.OrderId));
            if (!string.IsNullOrEmpty(filterOptions.StatusId))
                list = list.Where(i => i.StatusId == filterOptions.StatusId);
            if (!string.IsNullOrEmpty(filterOptions.Author))
                list = list.Where(i => i.UserName.Contains(filterOptions.Author));
            if (!string.IsNullOrEmpty(filterOptions.DateFrom) 
                && DateTime.TryParseExact(filterOptions.DateFrom, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateFrom))
                list = list.Where(i => i.OrderDate.Date >= dateFrom);
            if (!string.IsNullOrEmpty(filterOptions.DateTo) 
                && DateTime.TryParseExact(filterOptions.DateTo, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTo))
                list = list.Where(i => i.OrderDate.Date <= dateTo);
            if (!string.IsNullOrEmpty(filterOptions.Article))
                list = list.Where(i => i.Positions.Any(p=>p.WareNumber.Contains(filterOptions.Article)));

            var selection = list.ToArray();

            var result = new OrderList {Total = selection.Length};

            var ordered = selection.OrderByDescending(i => i.OrderDate).ThenByDescending(i=>i.Id)
                .Skip((pageOptions.PageNumber - 1) * pageOptions.PageSize).Take(pageOptions.PageSize);

            foreach (var item in ordered)
            {
                if (item.Positions == null) continue;
                var orderListItem = new OrderListItem
                {
                    Id = item.Id,
                    Number = item.Number,
                    ClientId = item.ClientId,
                    OrderDate = item.OrderDate,
                    Sum = item.Sum,
                    StatusId = item.StatusId,
                    StatusName = item.StatusName,
                    UserId = item.UserId,
                    UserName = item.UserName,
                    Options = item.Options,
                    DeliveryInfo = item.DeliveryInfo,
                    PaymentInfo = item.PaymentInfo,
                    CanDelete = item.CanDelete,
                    DeleteBlockMessage = item.DeleteBlockMessage,
                    CanChange = item.CanChange,
                    ChangeBlockMessage = item.ChangeBlockMessage,
                    IsReserved = item.IsReserved,
                    AllowTransmissionAct = item.AllowTransmissionAct,
                    PosStatuses = item.Positions.Select(i => new PositionStatus
                    {
                        StatusId = i.StatusId,
                        StatusName = i.StatusName,
                        Qnt = (int)i.WareQnt
                    }).ToList()
                };
                result.List.Add(orderListItem);
            }
            // order to orderlist
            return result;
        }

        public List<OrderListItem> GetPublicOrderList(string locale, string warehouseId)
        {
            throw new NotImplementedException();
        }

        public OrderPositionsList GetOrderPositionsList(string clientId, OrderFilterOptions filter, PageOptions options)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(string locale, string clientId, string orderId, bool onlyHeader = false)
        {
            // get orderList id
            var test = _testData.Orders.FirstOrDefault(i => i.Id == orderId);
            return test;
        }

        public string CreateOrder(CheckoutOrderData orderData)
        {
            var id = _testData.Orders.Count+1;
            var testOrder = new Order
            {
                Id = id.ToString(),
                Number = "0000" + id,
                ClientId = orderData.ClientId,
                OrderDate = DateTime.Now,
                Sum = 0,
                StatusId = "1",
                StatusName = "created",
                UserId = orderData.AuthorId,
                UserName = orderData.AuthorName,
                Options = orderData.Options,
                DeliveryInfo = new DeliveryInfo
                {
                    DeliveryTypeId = orderData.Delivery.DeliveryTypeId,
                    PickUpPayload = new PickUpPayload
                    {
                        PickupTime = DateTime.Now
                    },
                    DeliveryPayload = orderData.Delivery.DeliveryPayload
                },
                PaymentInfo = new PaymentInfo(),
                CanDelete = true,
                CanChange = true,
                Positions = new List<OrderPosition>()
            };

            foreach (var item in orderData.Positions)
            {
                var orderPos = new OrderPosition
                {
                    Id = item.Id.ToString(),
                    StatusId = "1",
                    StatusName = "Test",
                    ProducerId = item.ProducerId,
                    ProducerName = item.ProducerName,
                    WareId = item.WareId,
                    WareNumber = item.WareNum,
                    WareName = item.WareName,
                    WareQnt = item.WareQnt,
                    Price = item.ClientPrice,
                    Comment = item.Comment,
                    
                    DeliveryInfo = new DeliveryInfo
                    {
                        DeliveryTypeId = 1,
                        StatusId = "1",
                        StatusName = "test status",
                        PickUpPayload = new PickUpPayload
                        {
                            PickupPointId = "test PickupPointId",
                            PickupTime = DateTime.Now
                        },
                        DeliveryPayload = new DeliveryPayload
                        {
                            AddressId = "Test AddressId",
                            TransporterServiceId = "Test TransporterServiceId",
                            PickupPointId = "Test PickupPointId",
                            DeliveryMethodId = "Test DeliveryMethodId",
                            DeliveryMethodName = "Test DeliveryMethodName",
                            DeliveryTime = new DeliveryTime
                            {
                                Id = "1",
                                Date = DateTime.Now,
                                Description = "Test Description",
                                MaxDeliveryTime = new TimeSpan(),
                                MinDeliveryTime = new TimeSpan(),
                                MinOrderTime = DateTime.Now,
                                Unavailable = false
                            },
                            Insurance = true
                        }
                    }
                };
                testOrder.Positions.Add(orderPos);
            }
            testOrder.Sum = testOrder.Positions.Select(i => i.Sum).Sum();

            _testData.Orders.Add(testOrder);
            return testOrder.Id;
        }

        public string SetOrderDelivery(SetOrderDeliveryData deliveryData)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(User user, string id)
        {
            throw new NotImplementedException();
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
            return _testData.PickupPoints;
        }
    }
}
