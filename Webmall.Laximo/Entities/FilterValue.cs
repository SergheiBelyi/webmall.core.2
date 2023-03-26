using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Entities
{
    public class FilterValue
    {
        /// <summary>
        /// Наименование значения
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Модификатор SSD для вводимых значений
        /// </summary>
        public string SsdModification { get; set; }

        public FilterValue() { }

        public FilterValue(ValueRow row)
        {
            Name = row.name;
            Note = row.note;
            SsdModification = row.ssdmodification;
        }
    }
}
