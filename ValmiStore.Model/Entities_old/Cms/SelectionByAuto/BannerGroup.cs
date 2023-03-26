namespace ValmiStore.Model.Entities.Cms.SelectionByAuto
{
    /// <summary>
    /// Баннерная группа для формирования баннеров над списком товаров для подбора по авто
    /// </summary>
    public class BannerGroup
    {
        /// <summary>
        /// Идентификатор товарной группы
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// признак наличия первого баннера
        /// </summary>
        public bool IsBanner1Active { get; set; }
        /// <summary>
        /// Изображение первого баннера
        /// </summary>
        public string Banner1ImageUrl { get; set; }

        /// <summary>
        /// признак наличия второго баннера
        /// </summary>
        public bool IsBanner2Active { get; set; }
        /// <summary>
        /// Изображение второго баннера
        /// </summary>
        public string Banner2ImageUrl { get; set; }

        /// <summary>
        /// Ссылка для первого баннера
        /// </summary>
        public string Banner1Url { get; set; }

        /// <summary>
        /// Ссылка для второго баннера
        /// </summary>
        public string Banner2Url { get; set; }

        public static string GetUrl(string currentUrl, string bannerUrl)
        {
            if (string.IsNullOrEmpty(bannerUrl))
                return "";
            return bannerUrl.Substring(0, 1) == "&" ? ((currentUrl.Contains(bannerUrl)) ? currentUrl : currentUrl + bannerUrl) : bannerUrl;
        }
    }
}