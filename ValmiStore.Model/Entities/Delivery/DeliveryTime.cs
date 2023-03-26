using System;

namespace Webmall.Model.Entities.Delivery
{
    public class DeliveryTime
    {
        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public TimeSpan MinDeliveryTime { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public TimeSpan MaxDeliveryTime { get; set; }

        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public DateTime MinOrderTime { get; set; }
        /// <summary>
        /// Желаемая дата/время доставки
        /// </summary>
        public bool Unavailable { get; set; }
    }
}