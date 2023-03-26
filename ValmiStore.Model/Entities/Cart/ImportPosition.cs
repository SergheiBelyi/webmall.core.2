using Newtonsoft.Json;

namespace Webmall.Model.Entities.Cart
{
    public class ImportPosition
    {
        /// <summary>
        /// Каталожный номер товара
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Количество импортируемых позиций
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Наименование производителя
        /// </summary>
        public string Brand;

        public string Name;

        [JsonIgnore] public int? Id;

        //public List<ImportPositionCase> Cases = new List<ImportPositionCase>();
    }

    //public class ImportPositionCase
    //{
    //    /// <summary>
    //    /// Идентификатор товарной позиции
    //    /// </summary>
    //    public int? Id { get; set; }
        
    //    /// <summary>
    //    /// Наименование товарного бренда
    //    /// </summary>
    //    public string Brand { get; set; }

    //    /// <summary>
    //    /// Наименование товара
    //    /// </summary>
    //    public string Name { get; set; }
    //}

    //public enum ImportCriteria
    //{
    //    /// <summary>
    //    /// По наилучшей цене
    //    /// </summary>
    //    Price = 1,

    //    /// <summary>
    //    /// По наименьшему сроку
    //    /// </summary>
    //    Term = 2,
    //}
}
