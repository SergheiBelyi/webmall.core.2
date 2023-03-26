namespace Webmall.Model.Entities.Address
{
    public class PickupPointInfo
    {
        /// <summary>
        /// Идентификатор точки выдачи
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Наименование точки выдачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// График работы отделения
        /// </summary>
        public string Schedule { get; set; }

        /// <summary>
        /// Ограничение по весу посылки
        /// </summary>
        public int? MaxWeight { get; set; }

        /// <summary>
        /// Допускает наложенный платеж (null – по умолчанию у перевозчика)
        /// </summary>
        public bool? CanTakeMoney { get; set; }
    }
}