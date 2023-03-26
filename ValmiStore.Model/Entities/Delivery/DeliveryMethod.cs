using System.Collections.Generic;

namespace Webmall.Model.Entities.Delivery
{
    public class DeliveryMethod
    {
        /// <summary>
        /// Идентификатор метода доставки
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование метода
        /// </summary>
        public string Name{ get; set; }

        /// <summary>
        /// Доступное время доставки по расписанию
        /// </summary>
        public List<DeliveryTime> AvailableTimes { get; set; }
    }
}