using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Webmall.Model.Entities.Client
{
    public class Contact
    {
        public string Id { get; set; }

        /// <summary>
        /// ФИО контакта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Период действительности контакта (с)
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Период действительности контакта (по)
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Телефон контакта
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Признак доверенного лица
        /// </summary>
        public bool IsTrustee { get; set; }

        /// <summary>
        /// Номер документа доверенности
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Скан-копия доверенности
        /// </summary>
        [JsonIgnore]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
