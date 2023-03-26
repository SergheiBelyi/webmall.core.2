using System;

namespace ValmiStore.Model.Entities.Cms.Configuration
{
    public class TopBanner
    {
        /// <summary>
        /// Сыылка для перехода при клике на баннер
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Текст для вывода на баннере
        /// </summary> 
        public string Text { get; set; }

        /// <summary>
        /// Дата первого дня показа верхнего баннера 
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Дата последнего дня показа верхнего баннера 
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
