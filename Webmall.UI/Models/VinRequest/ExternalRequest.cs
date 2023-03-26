using System.ComponentModel.DataAnnotations;

namespace Webmall.UI.Models.VinRequest
{
    public class ExternalVINRequest
    {
        
        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources),  ErrorMessageResourceName = "IsRequired")]
        public string Name { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public string Email { get; set; }

        /// <summary>
        /// Нас. пункт
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// VINCode
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public string VINCode { get; set; }

        /// <summary>
        /// Марка
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public string Marka { get; set; }

        /// <summary>
        /// Модель
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public string Model { get; set; }

        /// <summary>
        /// Двигатель
        /// </summary>
        public string Engine { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ViewRes.SharedResources), ErrorMessageResourceName = "IsRequired")]
        public int? Year { get; set; }
        /// <summary>
        /// Оьъем
        /// </summary>
        public string Volume { get; set; }

        /// <summary>
        /// Кузов
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string Transmission { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

    }
}