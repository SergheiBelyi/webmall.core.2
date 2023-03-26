namespace Webmall.Model.Entities.Order
{
    public class OrderOptions
    {
        /// <summary>
        /// Комментарий к заказу
        /// </summary>
        public string Comment{ get; set; }

        /// <summary>
        /// Проверить заказ менеджером
        /// </summary>
        public bool NeedToCheck { get; set; }

        /// <summary>
        /// Код доверенного лица / Идентификатор контакта-доверенного лица (из списка контактов-доверенных лиц клиента)
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Телефон для связи / Контактный телефон (номер)
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// Идентификатор автомобиля из личного гаража
        /// </summary>
        public string VehicleId { get; set; }

    }
}