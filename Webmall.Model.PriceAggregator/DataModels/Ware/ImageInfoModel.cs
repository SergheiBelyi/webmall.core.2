namespace Webmall.Model.PriceAggregator.DataModels.Ware
{
    public class ImageInfoModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// URL (если надо)
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Сама картинка
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Высота (px)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Ширина (px)
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string MimeType { get; set; }
    }

}
