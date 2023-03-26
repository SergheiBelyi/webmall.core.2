using System.Collections.Generic;
using System.Linq;
using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Entities
{
    public class Filter
    {
        /// <summary>
        /// Наименование условия
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// list - Перечисляемый, input - Вводимый пользователем
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Список значений, если условие перечисляемое
        /// </summary>
        public List<FilterValue> Values { get; set; }
        /// <summary>
        /// Регулярное выражение, если значение вводится пользователем
        /// </summary>
        public string Regexp { get; set; }
        /// <summary>
        /// Модификатор SSD для вводимых значений. Символ $ должен быть заменен на введенное пользователем значение для условия.
        /// </summary>
        public string SsdModification { get; set; }

        public Filter() { }

        public Filter(FilterRow filter)
        {
            Name = filter.name;
            Type = filter.type;
            Regexp = filter.regexp;
            SsdModification = filter.ssdmodification;
            if (filter.values != null && filter.values.Any() && filter.values[0].row != null)
                Values = filter.values[0].row.Select(i => new FilterValue(i)).ToList();
        }
    }
}
