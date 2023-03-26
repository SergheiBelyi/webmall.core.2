using System;
using System.Collections.Generic;

namespace Webmall.Model.Entities.Delivery
{
    public class DeliveryMethods
    {
        /// <summary>
        /// Список доступных методов доставки
        /// </summary>
        public List<DeliveryMethod> List{ get; set; }

        /// <summary>
        /// Сообщение, если нет доступных методов для адреса (причина недоступности)
        /// </summary>
        public string Message { get; set; }
    }
}