using System;
using Webmall.Model;

namespace ValmiStore.Model.Entities.Order
{
    public class WareAvailability
    {
        /// <summary>
        /// Код товара
        /// </summary>
        public string WareId { get; set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseId { get; set; }

        /// <summary>
        /// Название склада
        /// </summary>
        public string WarehouseName { get; set; }

        ///// <summary>
        ///// код города склада
        ///// </summary>
        //int CityId { get; set; }

        /// <summary>
        /// наименование города склада
        /// </summary>
        public string CityName { get; set; }

         /// <summary>
        /// Количество товара, которое можно взять на этом складе
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// дата-время получения согласно графика доставки
        /// </summary>
        public DateTime? Available { get; set; }

        public string AvailablePresentator => Helper.DeliveryTermPresentator(Available);

        /// <summary>
        /// Является ли складом отгрузки
        /// </summary>
        public bool IsShippingWarehouse { get; set; }
    }
}
