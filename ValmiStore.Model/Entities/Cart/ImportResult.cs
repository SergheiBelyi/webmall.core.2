namespace Webmall.Model.Entities.Cart
{
    public class ImportResult
    {
        /// <summary>
        /// Каталожный номер товара
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Количество импортируемых позиций
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string Brand;

        /// <summary>
        /// Наименование связанного товара
        /// </summary>
        public string Name;

        /// <summary>
        /// Идентификатор созданной позиции корзины
        /// </summary>
        public string CartId;

        /// <summary>
        /// Сообщение об ошибке (null - импортировано успешно)
        /// </summary>
        public string Message;

        /// <summary>
        /// URL связанный с товарной позицией
        /// </summary>
        public string URL => "Auto" + "/" 
                             + Helper.RemoveBadURLSymbols(Brand, false) + "/"
                             + Helper.RemoveBadURLSymbols(Number, true);

        public string FullUrl;
    }
}
