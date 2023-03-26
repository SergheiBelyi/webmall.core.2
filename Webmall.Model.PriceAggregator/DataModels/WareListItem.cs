
namespace Webmall.Model.PriceAggregator.DataModels
{
    public class WareListItem
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор группы товара
        /// </summary>
        public string GroupUid { get; set; }

        /// <summary>
        /// Наименование группы товара
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Наименование товара
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id производителя
        /// </summary>
        public string ProducerId { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Каталожный номер
        /// </summary>
        public string WareNumber { get; set; }

        /// <summary>
        /// Ссылка на справочник ед. измерения
        /// </summary>
        public string UnitId { get; set; }

        /// <summary>
        /// Количество в упаковке
        /// </summary>
        public decimal? PackQnt { get; set; }

        /// <summary>
        /// Кратность использования
        /// </summary>
        public int UseMultipleQnt { get; set; } = 1;

        /// <summary>
        /// Нормализованный артикул товара
        /// </summary>
        public string WareNumNormal { get; set; }

        /// <summary>
        /// Баркод производителя
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// Срок годности товара в днях
        /// </summary>
        public int? ShelfLife { get; set; }

        /// <summary>
        /// Срок годности товара в днях
        /// </summary>
        public bool? IsOutOfProduction { get; set; }

        /// <summary>
        /// ид картинки товара
        /// </summary>
        public int? ImageId { get; set; }

        /// <summary>
        /// Наличие картинки у товара
        /// </summary>
        public bool HasImage { get; set; }
    }
}
