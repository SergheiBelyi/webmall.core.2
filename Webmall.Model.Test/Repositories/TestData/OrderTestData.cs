using System;
using System.Collections.Generic;
using Webmall.Model.Entities.Order;
// ReSharper disable InconsistentNaming

namespace Webmall.Model.Test.Repositories.TestData
{
    public class OrderTestData
    {
        public List<RefOrderStatus> OrderStatuses => _orderStatuses;
        private static readonly List<RefOrderStatus> _orderStatuses = new List<RefOrderStatus>
        {
            new RefOrderStatus
            {
                StatusId = "1",
                StatusName = "В обработке",
                IsFinal = false,
                Color = 0xf6ffca
            },
            new RefOrderStatus
            {
                StatusId = "2",
                StatusName = "Заказ у поставщика",
                IsFinal = true,
                Color = 0xe2eeff

            }
        };

        public List<RefOrderStatus> OrderPositionStatuses => _orderPositionStatuses;
        private static readonly List<RefOrderStatus> _orderPositionStatuses = new List<RefOrderStatus>
        {
            new RefOrderStatus
            {
                StatusId = "1",
                StatusName = "В обработке",
                IsFinal = false,
                Color = 0xf6ffca
            },
            new RefOrderStatus
            {
                StatusId = "2",
                StatusName = "Заказ у поставщика",
                IsFinal = true,
                Color = 0xe2eeff

            }
        };

        public List<PickupPointInfo> PickupPoints => _pickupPoints;
        private static readonly List<PickupPointInfo> _pickupPoints = new List<PickupPointInfo>
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

        public List<Order> Orders => _orders;
        private static readonly List<Order> _orders = new List<Order> {
            new Order {
                Id = "0",
                Number = "00000",
                ClientId = "9291",
                OrderDate = DateTime.Now.AddDays(-7),
                Sum = 077227,
                StatusId = _orderStatuses[0].StatusId,
                StatusName = _orderStatuses[0].StatusName,
                UserId = "999",
                UserName = "test username",
                Options = new OrderOptions(),
                 DeliveryInfo = new DeliveryInfo{
                    DeliveryTypeId = 1,
                    StatusId = "testStatusID",
                    StatusName = "самовывоз",
                    PickUpPayload = new PickUpPayload
                    {
                        PickupPointId = "Адрес склада отгрузки 55",
                        PickupTime = new DateTime()
                    },
                    DeliveryPayload = new DeliveryPayload()

                },
                PaymentInfo = new PaymentInfo(),
                CanDelete = false,
                DeleteBlockMessage = "",
                CanChange = false,
                ChangeBlockMessage = "",
                IsReserved = true,
                AllowTransmissionAct = false,
                Positions = new List<OrderPosition>
                {
                    new OrderPosition
                    {
                        WareQnt = 5,
                        StatusId = _orderStatuses[0].StatusId,
                        StatusName = _orderStatuses[0].StatusName,
                        Price = 123,
                        Id = "21341223",
                        ProducerId = "1233",
                        ProducerName = "producerName fdewf",
                        WareId = "12",
                        WareNumber = "asdfqe",
                        WareName = "asdaf",
                        Comment = "asf asd",
                        IsReserved = false,
                        Weight = 0
                    }
                }
            },

            new Order
            {
                Id = "1",
                Number = "00001",
                ClientId = "99",
                OrderDate = DateTime.Now.AddDays(-3),
                Sum = 777,
                StatusId = _orderStatuses[0].StatusId,
                StatusName = _orderStatuses[0].StatusName,
                UserId = "999",
                UserName = "test username",
                Options = new OrderOptions(),
                Positions = new List<OrderPosition>
                {
                    new OrderPosition
                    {
                        WareQnt = 5,
                        StatusId = _orderStatuses[0].StatusId,
                        StatusName = _orderStatuses[0].StatusName,
                        Price = 123,
                        Id = "21341223",
                        ProducerId = "1233",
                        ProducerName = "producerName fdewf",
                        WareId = "12",
                        WareNumber = "asdfqe",
                        WareName = "asdaf",
                        Comment = "asf asd",
                        IsReserved = false,
                        Weight = 0
                    }
                },
                 DeliveryInfo = new DeliveryInfo{
                    DeliveryTypeId = 1,
                    StatusId = "testStatusID",
                    StatusName = "самовывоз",
                    PickUpPayload = new PickUpPayload
                    {
                        PickupPointId = "Адрес склада отгрузки 55",
                        PickupTime = new DateTime()
                    },
                    DeliveryPayload = new DeliveryPayload()

                },
                PaymentInfo = new PaymentInfo(),
                CanDelete = true,
                DeleteBlockMessage = "DeleteBlockMessage test",
                CanChange = true,
                ChangeBlockMessage = "ChangeBlockMessage test",
                IsReserved = true,
                AllowTransmissionAct = true
            },
            new Order
            {
                Id = "2",
                Number = "00002",
                ClientId = "9291",
                OrderDate = DateTime.Now,
                Sum = 77227,
                StatusId = _orderStatuses[1].StatusId,
                StatusName = _orderStatuses[1].StatusName,
                UserId = "999",
                UserName = "test username",
                Options = new OrderOptions{ 
                    Comment = "test Com",
                    ContactPhone = "9379992"
                },
                Positions = new List<OrderPosition>
                {
                    new OrderPosition
                    {
                        WareQnt = 2,
                        StatusId = _orderStatuses[1].StatusId,
                        StatusName = _orderStatuses[1].StatusName,
                        Price = 1232,
                        Id = "213412",
                        ProducerId = "122223",
                        ProducerName = "producerNamedferded",
                        WareId = "1",
                        WareNumber = "asdfqe",
                        WareName = "asdaf",
                        Comment = "test comment",
                        IsReserved = false,
                        Weight = 0
                    },
                    new OrderPosition
                    {
                        WareQnt = 244,
                        StatusId = _orderStatuses[1].StatusId,
                        StatusName = _orderStatuses[1].StatusName,
                        Price = 32,
                        Id = "2134122",
                        ProducerId = "122223",
                        ProducerName = "producerNamedferded",
                        WareId = "1",
                        WareNumber = "asdfqe",
                        WareName = "asdaf",
                        Comment = "23423 comment",
                        IsReserved = false,
                        Weight = 0
                    },
                    new OrderPosition
                    {
                        WareQnt = 20,
                        StatusId = _orderStatuses[1].StatusId,
                        StatusName = _orderStatuses[1].StatusName,
                        Price = 11,
                        Id = "2134123",
                        ProducerId = "122223",
                        ProducerName = "producerNamedferded12",
                        WareId = "1",
                        WareNumber = "asdfqe",
                        WareName = "asdaf",
                        Comment = "test comment 1234 23 4",
                        IsReserved = false,
                        Weight = 0
                    }
                },
                DeliveryInfo = new DeliveryInfo{ 
                    DeliveryTypeId = 1,
                    StatusId = "testStatusID",
                    StatusName = "самовывоз",
                    PickUpPayload = new PickUpPayload
                    {
                        PickupPointId = "Адрес склада отгрузки 55",
                        PickupTime = new DateTime()
                    },
                    DeliveryPayload = new DeliveryPayload()
                    
                },
                PaymentInfo = new PaymentInfo(),
                CanDelete = true,
                DeleteBlockMessage = "DeleteBlockMessage test",
                CanChange = true,
                ChangeBlockMessage = "ChangeBlockMessage test",
                IsReserved = true,
                AllowTransmissionAct = true
            }
        };

    }
}
