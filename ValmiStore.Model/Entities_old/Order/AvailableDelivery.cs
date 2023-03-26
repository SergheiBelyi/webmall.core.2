using System;

namespace ValmiStore.Model.Entities.Order
{
    public class AvailableDelivery
    {
        public AvailableDelivery()
        {
            MinimalDate = DateTime.Now.Date;
        }

        public string Presentation
        {
            get
            {
                if (DeliveryDate.HasValue)
                    return $"{Address} - {DeliveryDate:dd/MM/yyyy hh:mm}";
                return Address;
            }
        }

        public string DatePresentation => $"{DeliveryDate:dd/MM/yyyy}";

        public string MinimalDatePresentation => $"{MinimalDate:dd/MM/yyyy}";


        public string TimePresentation
        {
            get
            {
                if (DeliveryDate != null)
                    if (GoTime.HasValue)
                        return $"{GoTime:HH:mm} - {DeliveryDate:HH:mm}";
                    else
                        return $"{ViewRes.SharedResources.to} {DeliveryDate:HH:mm}";
                return "";
            }
        }

        public string CostPresentation => $"{Cost:n}";

        public int? Id { get; set; }
        public string DeliveryTypeId { get; set; }
        public string DeliveryAddressId { get; set; }
        public string Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? Cost { get; set; }
        public bool NeedTaxBill { get; set; }
        public bool NeedAllTaxBills { get; set; }
        public DateTime FilterDate { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? GoTime { get; set; }
        public bool Added { get; set; }
        // Минимально возможная дата доставки
        public DateTime MinimalDate { get; set; }

        /// <summary>
        /// Признак собственного транспорта
        /// </summary>
        public bool IsOurTransport { get; set; }
    }
}
