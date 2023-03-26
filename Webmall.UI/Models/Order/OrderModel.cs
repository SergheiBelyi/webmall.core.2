using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ValmiStore.Model.Entities.Order;
using Webmall.Model.Entities;
using Webmall.Model.Entities.Client;
using Webmall.Model.Entities.Delivery;
using OrderData = ValmiStore.Model.Entities.Order.Order;

namespace Webmall.UI.Models.Order
{
    public class OrderModel
    {
        private OrderData _order;

        public OrderModel()
        {
            Warehouses = new List<Warehouse>();
            Agreements = new List<Contract>();
            DeliveryAddress = new List<DeliveryAddress>();
            Schedules = new List<DeliverySchedule>();
            VisaInfo = new VisaAdditionalInfo();
            //EPayKKBInfo = new EPayKKBAdditionalInfo();
            ClientsDeliveryInfo = new AvailableDelivery();
        }

        public OrderData Order
        {
            get => _order;
            set
            {
                _order = value;
                ClientsDeliveryInfo = _order?.Delivery;
                if (ClientsDeliveryInfo?.DeliveryDate?.Date != null)
                    ClientsDeliveryInfo.DeliveryDate = ClientsDeliveryInfo.DeliveryDate.Value.Date;
            }
        }

        public List<Warehouse> Warehouses { get; set; }
        public List<Contract> Agreements { get; set; }
        public List<DeliveryAddress> DeliveryAddress { get; set; }
        public List<DeliverySchedule> Schedules { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool? ShowPaymentFirst { get; set; }
        public string DebtMessage { get; set; }
        public VisaAdditionalInfo VisaInfo { get; set; }
        //public EPayKKBAdditionalInfo EPayKKBInfo { get; set; }
        
        public AvailableDelivery ClientsDeliveryInfo { get; set; }

        public List<SelectListItem> DeliveryTypes { get; set; }

    }

    public class ClientsDeliveryInfo
    {
        public string AddressId { get; set; }
        
        public string DeliveryTypeId { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}