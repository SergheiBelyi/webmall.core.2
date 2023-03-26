using System.Collections.Generic;
using System.Linq;
using ValmiStore.Model.Entities;

namespace Webmall.UI.Models.WareComparision
{
    public class ComparisionModel
    {
        public ComparisionList ComparisionList { get; set; }
        public Dictionary<string, bool> Properties
        {
            get
            {
                var resultQuery = (new List <WareProperty>()).Select(i=>i).AsQueryable();
                resultQuery = ComparisionList.Aggregate(resultQuery, (current, ware) => current.Union(ware.Properties.Select(i => i)));
                var props = resultQuery.GroupBy(i=>i.Name).Select(i=>new {Name = i.Key, Importance = i.Max(el=>el.Importance)}).Distinct().OrderByDescending(i=>i.Importance).ThenBy(i=>i.Name).ToList();
                var result = new Dictionary<string, bool>();
                foreach (var prop in props)
                {
                    var resultQuery2 = (new List<string>()).Select(i => i).AsQueryable();
                    var values =
                        ComparisionList.Aggregate(resultQuery2,
                            (current, ware) =>
                                current.Union(
                                    ware.Properties.Where(i => i.Name == prop.Name).Select(i => i.Value)))
                            .Distinct();
                    result.Add(prop.Name, values.Count()>1);
                }
                return result;
            }
        }
    }
}