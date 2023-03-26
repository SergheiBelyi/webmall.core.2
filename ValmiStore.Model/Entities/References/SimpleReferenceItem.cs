using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewRes;

namespace Webmall.Model.Entities.References
{
    /// <summary>
    /// Простой справочник
    /// </summary>
    public class SimpleReferenceItem
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }

        /// <summary>
        /// Формирует справочник с возможностью выбора пустого значения
        /// </summary>
        /// <param name="data">Справочник</param>
        /// <param name="allowEmpty">Нужно ли пустое значение</param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Convert(IEnumerable<SimpleReferenceItem> data, bool allowEmpty)
        {
            var list = data.Select(i => new SelectListItem { Text = i.Value, Value = i.Id.ToString() }).ToList();
            if (allowEmpty) list.Insert(0, new SelectListItem { Text = $@"<{SharedResources.notSelected}>", Value = "-1" });
            return list;
        }
    }
}
