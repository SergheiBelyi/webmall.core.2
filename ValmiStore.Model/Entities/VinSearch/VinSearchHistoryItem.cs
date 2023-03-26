using System;

namespace Webmall.Model.Entities.VinSearch
{
    public class VinSearchHistoryItem
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// VIN-код автомобиля
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// VIN-код автомобиля
        /// </summary>
        public string AutoName { get; set; }

        /// <summary>
        /// Признак успешности запроса
        /// </summary>
        public bool? IsSuccessful { get; set; }

        /// <summary>
        /// Код отправившего запрос пользователя
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// IP отправившего запрос пользователя
        /// </summary>
        public string UserIP { get; set; }

    }
}
