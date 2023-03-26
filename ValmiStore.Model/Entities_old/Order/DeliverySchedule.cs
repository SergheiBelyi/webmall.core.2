using System;

namespace ValmiStore.Model.Entities.Order
{
    public class DeliverySchedule
    {
        /// <summary>
        /// Код графика доставки
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Наименование маршрута
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// Дата/время получения заказа
        /// </summary>
        public DateTime? ReceiveTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? GoTime { get; set; }

        /// <summary>
        /// Дата время поставки заказа клиенту
        /// </summary>
        public DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// Наименование тарифа
        /// </summary>
        public string TariffName { get; set; }

        /// <summary>
        /// Наимеование типа тарифа
        /// </summary>
        public string TariffTypeName { get; set; }

        /// <summary>
        /// Сумма тарифа
        /// </summary>
        public decimal? TariffSum { get; set; }

        /// <summary>
        /// Процент по тарифу
        /// </summary>
        public decimal? TariffProcent { get; set; }

        /// <summary>
        /// Ограничение
        /// </summary>
        public string ConstraintTypeName { get; set; }

        /// <summary>
        /// Признак собственного транспорта
        /// </summary>
        public bool IsOurTransport { get; set; }

        /// <summary>
        /// Внешний URL для ссылки
        /// </summary>
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Служба доставки
        /// </summary>
        public string DeliveryService { get; set; }

        /// <summary>
        /// Признак внешней службы доставки
        /// </summary>
        public bool IsExternalDeliveryService { get; set; }
    }
}
