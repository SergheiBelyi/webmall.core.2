using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Entities.Auto;

namespace Webmall.UI.Models.SelectionByAuto
{
    public class SelectionByAutoMarkModel
    {
        public int? AutoMark { get; set; }
        public string AutoMarkUrl { get; set; }
        public AutoMarka AutoMarkaObj { get; set; }
        public AutoMarka CurrentAutoMarkaObj { get; set; }
        public int? AutoModel { get; set; }
        public int? AutoModif { get; set; }
        public List<AutoMarka> AutoMarkList { get; set; }
        public List<AutoMarka> TrackAutoMarkList { get; set; }
        public bool AllowTrackSelection => TrackAutoMarkList?.Any() == true;
        public bool AllowLaximoAutoSelection { get; set; }
        public List<AutoModel> AutoModelList { get; set; }
        public List<AutoModification> AutoModifList { get; set; }
        public List<SelectListItem> FuelTypes { get; set; }
        public string ModifName { get; set; }
        public List<KeyValuePair<string, string>> LaximoCatalogList { get; set; }
    }
}