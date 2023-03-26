using System;

namespace ValmiStore.Model.Entities.User
{
    public class NotificationHistoryItem
    {
        /// <summary>
        /// Тема
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст уведомления
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Адрес, на который было отправлено сообщение
        /// </summary>
        public string Address { get; set; }
    }
}
