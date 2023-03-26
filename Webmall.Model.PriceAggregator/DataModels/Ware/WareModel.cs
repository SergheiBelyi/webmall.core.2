using System.Collections.Generic;

namespace Webmall.Model.PriceAggregator.DataModels.Ware
{
    public class WareModel
    {
        public WareData WareData { get; set; }

        public WareAddFeature Features { get; set; }

        /// <summary>
        /// Признак, что товар является оригинальным
        /// </summary>
        public bool IsOem { get; set; }

        ///// <summary>
        ///// Срок гарантии (в месяцах)
        ///// </summary>
        //public int? Warranty { get; set; }

        /// <summary>
        /// Коды картинок товара
        /// </summary>
        public IList<ImageInfoModel> Images { get; set; } = new List<ImageInfoModel>();

        ///// <summary>
        ///// Наличие изображения
        ///// </summary>
        //public bool HasImage { get; set; }

        public List<FileInfo> Files { get; set; }

        /// <summary>
        /// Рейтинг товара по отзывам
        /// </summary>
        public decimal? ReviewRate { get; set; }


    }
}
