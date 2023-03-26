namespace SERP.Product.Api.Domain.Models.ViewModels
{
    // BaseNumberType
    /// <summary>
    /// Типы базовых номеров
    /// </summary>
    public class BaseNumberTypeViewModel
    {
        /// <summary>
        /// Код типа базового номера
        /// </summary>
        public int BaseNumberTypeId { get; set; } // BaseNumberTypeId (Primary key)

        /// <summary>
        /// Название типа базового номера
        /// </summary>
        public string BaseNumberTypeName { get; set; } // BaseNumberTypeName (length: 100)

    }
}
