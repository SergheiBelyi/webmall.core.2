namespace Webmall.Model.Entities.Address
{
    public class CarrierServiceInfo
    {
        /// <summary>
        /// Идентификатор службы перевозки
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование службы перевозки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Признак доставки на адрес
        /// </summary>
        public bool IsToDoor { get; set; }

        /// <summary>
        /// Допускает наложенный платеж
        /// </summary>
        public bool CanTakeMoney { get; set; }
    }
}