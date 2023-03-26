using System.Collections.Generic;
using System.Web.Mvc;
using ValmiStore.Model.Entities.Cms.AutoService;

namespace Webmall.UI.Models
{
    public class ServiceBookingModel
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public List<SelectListItem> AutoMark { get; set; }
        public List<SelectListItem> AutoModel { get; set; }
        public List<SelectListItem> Modifications { get; set; }
        public List<AutoServiceInfo> Services { get; set; }

        public ServiceBookingModel()
        {
            AutoMark = new List<SelectListItem>();
            AutoModel = new List<SelectListItem>();
            Modifications = new List<SelectListItem>();
            Services = new List<AutoServiceInfo>();
        }

    }
}