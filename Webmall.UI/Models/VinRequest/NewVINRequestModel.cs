using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Entities.User;

namespace Webmall.UI.Models.VinRequest
{
    public class NewVINRequestModel
    {
        public NewVINRequestModel()
        {
            AutoMark = new List<SelectListItem>();
            AutoModel = new List<SelectListItem>();
            Modifications = new List<SelectListItem>();
            Request =  new VINRequest ();
        }
        public List<SelectListItem> AutoMark { get; set; }
        public string SelectedAutoMarkId { get => Request.MarkaId.ToString();
            set { Request.MarkaId = int.Parse(value); Request.ModelName = AutoMark.First(i => i.Value == value).Text; }
        }
        public List<SelectListItem> AutoModel { get; set; }
        public string SelectedAutoModelId { get => Request.ModelId.ToString();
            set { Request.ModelId = int.Parse(value); Request.ModelName = AutoModel.First(i => i.Value == value).Text; }
        }
        public List<SelectListItem> Modifications { get; set; }
        public string SelectedModificationId { get => Request.ModifId.ToString();
            set { Request.ModifId = int.Parse(value); Request.ModelName = Modifications.First(i => i.Value == value).Text; }
        }
        public VINRequest Request { get; set; }
    }
}