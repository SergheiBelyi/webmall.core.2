using Webmall.Model.Entities.References;

namespace Webmall.Model.Entities
{
    public class Warehouse : SimpleReferenceItem
    {
        /// <summary>
        /// Адрес склада
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Разрешена ли на складе оплата наличными
        /// </summary>
        public bool CashIsPossible { get; set; }
    }
}
