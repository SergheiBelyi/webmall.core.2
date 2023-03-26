using System.Collections.Generic;
using System.Web.Mvc;
using ValmiStore.Model.Entities.User;

namespace Webmall.UI.Models
{
    public class LoyaltyModel
    {
        public List<LoyaltyListItem> List { get; set; }
        public List<SelectListItem> Years { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Quaters { get; set; } = new List<SelectListItem>();
    }
}