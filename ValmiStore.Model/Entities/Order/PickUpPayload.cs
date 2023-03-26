using System;

namespace Webmall.Model.Entities.Order
{
    public class PickUpPayload
    {
        /// <summary>
        /// Идентификатор пункта самовывоза
        /// </summary>
        public string PickupPointId { get; set; }

        /// <summary>
        /// Наименование пункта самовывоза
        /// </summary>
        public string PickupPointName { get; set; }

        /// <summary>
        /// Планируемая дата/время отгрузки
        /// </summary>
        public DateTime? PickupTime { get; set; }

        /// <summary>
        /// Необходимость срочной сборки заказа
        /// </summary>
        public bool? CollectUrgently { get; set; }

        /// <summary>
        /// Отгружать по доступности
        /// </summary>
        public bool? DeliveryAvailable { get; set; }
    }
}