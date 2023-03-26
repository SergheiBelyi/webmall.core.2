using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Models.VinRequest;

namespace Webmall.UI.Controllers
{
    public class VINRequestController : Controller
    {
        readonly ICatalogRepository _catRep;
        private readonly IVinRequestRepository _vinRepository;

        public VINRequestController(ICatalogRepository catRep, IVinRequestRepository vinRepository)
        {
            _vinRepository = vinRepository;
            _catRep = catRep;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index(GridViewOptions options, int? isResponded, string partName, DateTime? requestEndDate, DateTime? requestStartDate)
        {
            if (string.IsNullOrEmpty(options.SortColumn))
            {
                options.SortColumn = "SendDate";
                options.SortDirection = SortDirection.Descending;
            }
            var vinRequestFilter = new VINRequestFilter {
                IsResponded = isResponded.HasValue ? (isResponded.Value == 0 ? null : isResponded.Value == 1 ? (bool?)true : false) : null,
                PartName = partName,
                RequestEndDate = requestEndDate,
                RequestStartDate = requestStartDate 
            };
            var result = _vinRepository.GetUserRequestsList(SessionHelper.CurrentUser, vinRequestFilter).AsGridView(ControllerContext, options, null);
            return View(result);
        }

        [Authorize]
        public ActionResult ViewRequest(int id)
        {
            var result = _vinRepository.GetVINRequest (SessionHelper.CurrentUser, id);
            return View(result);
        }

        [Authorize]
        public ActionResult NewRequest()
        {
            var model = new NewVINRequestModel();

            /*var marks = _catRep.GetAutoMarkaList(UserPreferences.CurrentCulture);
            foreach (var mark in marks)
                model.AutoMark.Add (new SelectListItem { Value = mark.Id.ToString(), Text = mark.Name});*/
            SessionHelper.CurrentUser.VINRequestPositions.Clear();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult NewRequest(NewVINRequestModel requestModel)
        {
            //var model = new NewVINRequestModel();
            requestModel.Request.Parts = SessionHelper.CurrentUser.VINRequestPositions;
            requestModel.Request.SendDate = DateTime.Now;
            //var marks = _catRep.GetAutoMarkaList(UserPreferences.CurrentCulture);
           // var models = requestModel.Request.MarkaId.HasValue ? _catRep.GetAutoModelList(UserPreferences.CurrentCulture, requestModel.Request.MarkaId.Value) : new List<AutoModel>();
            //var modifs = requestModel.Request.ModelId.HasValue ? _catRep.GetAutoModifList(UserPreferences.CurrentCulture, requestModel.Request.ModelId.Value) : new List<AutoModification>();
            //requestModel.Request.MarkaName = marks.First(i => i.Id == requestModel.Request.MarkaId).Name;
            //requestModel.Request.ModelName = models.First(i => i.Id == requestModel.Request.ModelId).Name;
            //requestModel.Request.ModifName = modifs.First(i => i.Id == requestModel.Request.ModifId).Name;
            _vinRepository.SaveVINRequest(SessionHelper.CurrentUser, requestModel.Request);

            //MailHelper.SendVINRequestMessage(SessionHelper.CurrentUser, requestModel.Request);
            //var marks = catRep.GetAutoMarkaList(UserPreferences.CurrentCulture);
            //foreach (var mark in marks)
            //    requestModel.AutoMark.Add(new SelectListItem() { Value = mark.Id.ToString(), Text = mark.Name });
            SessionHelper.CurrentUser.VINRequestPositions.Clear();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveRequest(string[] delete)
        {
            _vinRepository.RemoveVINRequests(SessionHelper.CurrentUser, delete.Where(i => i != "false").ToList());
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult ChangePosition(string pos, int value, string act)
        {
            if (act.ToLower() == "a")
            {
                if (SessionHelper.CurrentUser.VINRequestPositions.Count (i=>i.Description == pos) == 0)
                {
                    SessionHelper.CurrentUser.VINRequestPositions.Add(new PartInfo { Description = pos, Quantity = value});
                }
            }
            if (act.ToLower() == "d")
                SessionHelper.CurrentUser.VINRequestPositions.Remove(SessionHelper.CurrentUser.VINRequestPositions.FirstOrDefault(i => i.Description == pos));
            return View("NewRequestPositions");
        }

        [HttpPost]
        [Authorize]
        public ActionResult MakeOrUpdateResponse(int id, int posid, string wareNums, string responseComment)
        {
            _vinRepository.SaveVINRequestAnswer(posid, wareNums, responseComment);
            return RedirectToAction("ViewRequest", new { id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult MarkVINRequestAsAnswered(int id)
        {
            _vinRepository.MarkVINRequestAsAnswered(id);
            return RedirectToAction("Index");
        }

        //public ActionResult External()
        //{
        //    var model = new ExternalVINRequest
        //                {
        //                    Name = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.FIO : null,
        //                    Email = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.Email : null,
        //                    Phone = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.PhoneMobile ?? SessionHelper.CurrentUser.PhoneHome : null,
        //                };
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult External(ExternalVINRequest requestModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        requestModel.Description = requestModel.Description.Replace("\r\n", "<br>");
        //        MailHelper.SendVINRequestExternalMessage(requestModel.Email, requestModel.Name, requestModel);
        //        ViewBag.OrderAccepted = true;
        //        ModelState.Clear();
        //        requestModel = new ExternalVINRequest
        //        {
        //            Name = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.FIO : null,
        //            Email = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.Email : null,
        //            Phone = (SessionHelper.CurrentUser != null) ? SessionHelper.CurrentUser.PhoneMobile ?? SessionHelper.CurrentUser.PhoneHome : null,
        //        };
        //    }
        //    return View(requestModel);
        //}

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetModel(string id)
        {
            int intId;

            var tmp = (int.TryParse(id, out intId))
                ? null//_catRep.GetAutoModelList(UserPreferences.CurrentCulture, intId).Select(i => new SelectListItem {Value = i.Id.ToString(), Text = i.Name}).ToArray()
                : new SelectListItem[0];
            return Json(tmp, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetModif(string id)
        {
            return null;
            //return Json(_catRep.GetAutoModifList(UserPreferences.CurrentCulture, int.Parse (id)).Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }).ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}
