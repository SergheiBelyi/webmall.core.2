using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;
using Webmall.Model.Entities.VinSearch;

namespace Webmall.UI.Models.Laximo
{
    public class VehicleListModel : BaseModel
    {
        public string Vin { get; set; } = "";
        public List<VehicleInfo> Vehicles { get; set; } = new List<VehicleInfo>();

        public List<VinSearchHistoryItem> SearchHistory { get; set; }

        private Dictionary<string, string> _extAttrTitles;
        public Dictionary<string, string> ExtAttrTitles
        {
            get
            {
                return _extAttrTitles ?? (_extAttrTitles = Vehicles.Aggregate(new Dictionary<string, string>(), (s, info) =>
                {
                    if (info.ExtAttributes != null)
                    {
                        foreach (var item in info.ExtAttributes)
                        {
                            if (!s.ContainsKey(item.Key))
                                s.Add(item.Key, item.Name);
                        }
                    }

                    return s;
                }));
            }
        }
    }
}