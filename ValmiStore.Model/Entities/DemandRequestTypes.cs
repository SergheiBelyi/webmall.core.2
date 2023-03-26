namespace Webmall.Model.Entities
{
    /// <summary>
    /// Типы запросов для неуд. спроса
    /// </summary>
    public enum DemandRequestTypes
    {
        /// <summary>
        /// Поиск (механизм поиска)
        /// </summary>
        Search = 1,

        /// <summary>
        /// Вход в карточку товара
        /// </summary>
        Open = 2,

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        AddToCart = 3,

        /// <summary>
        /// Импорт корзины
        /// </summary>
        Import = 4,

        /// <summary>
        /// Поиск по автомобилю
        /// </summary>
        SearchByAuto = 5,

        /// <summary>
        /// Поиск по каталогу
        /// </summary>
        SearchByCatalog = 6,
    }
}