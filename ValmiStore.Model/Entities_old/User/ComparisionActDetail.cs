namespace ValmiStore.Model.Entities.User
{
    public class ComparisionActDetail
    {
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Наименование производителя (бренд)
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string WareNum { get; set; }

        /// <summary>
        /// Кол-во
        /// </summary>
        public decimal WareQnt { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Код заказа
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Дата заказа
        /// </summary>
        public string OrderDate { get; set; }

        /// <summary>
        /// Тип возврата
        /// </summary>
        public string ReturningType { get; set; }
    }
}
