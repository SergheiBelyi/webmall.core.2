namespace Webmall.Model.PriceAggregator.DataModels.AutoData
{
    /// <summary>
    /// Data for Auto marks
    /// </summary>
    public class AutoMarka
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        public string Uid { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Короткое наименование
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Описательный текст (в нижней части страницы по маркам)
        /// </summary>
        public string Description { get; set; }

        ///// <summary>
        ///// Models list
        ///// </summary>
        //public List<AutoModel> Models { get; set; } = new();
    }
}
