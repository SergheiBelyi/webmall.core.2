using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using ValmiStore.Model.Entities.User;
using ViewRes;
using Webmall.Model;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Models;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class ComparisionActController : Controller
    {
        private readonly IFinanceRepository _financeRepository;

        public ComparisionActController(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (!SessionHelper.CurrentUser.CurrentPresenter.IsComparisionUser)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ComparisionActModel();
            PrepareModel(model);

            model.List = _financeRepository.GetComparisionAct(SessionHelper.CurrentUser, model.StartDateAsDate, model.EndDateAsDate, UserPreferences.CurrentCulture, null);
            if (model.List == null)
            {
                TempData["Title"] = SharedResources.Error;
                TempData["Message"] = SharedResources.ComparisionActErrorMessage;
                return RedirectToAction("Show", "Message");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ComparisionActModel model)
        {
            if (!SessionHelper.CurrentUser.CurrentPresenter.IsComparisionUser)
            {
                return RedirectToAction("Index", "Home");
            }

            var filter = CommonHelpers.GetFilter(Request.Params);

            PrepareModel(model);

            if (ModelState.IsValid)
            {
                if (model.StartDateAsDate > model.EndDateAsDate)
                    ModelState.AddModelError("StartDate", SharedResources.ComparisionActPeriodError);
                else
                {
                    model.List = _financeRepository.GetComparisionAct(SessionHelper.CurrentUser, model.StartDateAsDate, model.EndDateAsDate,
                        UserPreferences.CurrentCulture, filter);
                }
            }

            return View(model);
        }

        private void PrepareModel(ComparisionActModel model)
        {
            ViewBag.Title = SharedResources.ComparisionAct;
            model.MinDate = ConfigHelper.MinComparisionActDate;
            model.ValuteName = SessionHelper.CurrentValute.Code;

            var startDate = DateTime.TryParseExact(model.StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var minDateValue) ? minDateValue : new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = DateTime.TryParseExact(model.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var maxDateValue) ? maxDateValue : DateTime.Now;

            if (startDate < model.MinDate)
                startDate = model.MinDate;
            if (endDate < model.MinDate)
                endDate = model.MinDate;

            if (startDate > endDate)
                startDate = endDate;

            model.StartDateAsDate = startDate;// = new DateTime (2019,10,1);
            model.EndDateAsDate = endDate;
            //model.DocTypes = GetDocumentType(docTypeId);
            //model.PaymentForms = GetPaymentForms(paymentFormId);
            //model.PaymentStatuses = GetPaymentStatuses(paymentStatusId);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetDetail(string detailId)
        {
            List<ComparisionActDetail> detail;
            var p = detailId.Split(",");
            var docId = p[0].Trim();
            var docTypeId = p[1].Trim();
            if (SessionHelper.CurrentUser.CurrentPresenter.IsComparisionUser && p.Length == 2 && !string.IsNullOrEmpty(docId) && !string.IsNullOrEmpty(docTypeId))
            {
                detail = _financeRepository.GetComparisionActDetail(SessionHelper.CurrentUser, docId, docTypeId,
                                                                UserPreferences.CurrentCulture);
            }
            else
            {
                detail = new List<ComparisionActDetail>();
            }
            return new JsonResult { Data = detail, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [AcceptVerbs(HttpVerbs.Get)]
        // [ValidateInput(false)]
        public ActionResult GetDetailRows(string detailId, bool mobile = false)
        {
            List<ComparisionActDetail> detail;
            var p = detailId.Split(",");
            var docId = p[0].Trim();
            var docTypeId = p[1].Trim();
            if (SessionHelper.CurrentUser.CurrentPresenter.IsComparisionUser && p.Length == 2 && !string.IsNullOrEmpty(docId) && !string.IsNullOrEmpty(docTypeId))
            {
                detail = _financeRepository.GetComparisionActDetail(SessionHelper.CurrentUser, docId, docTypeId,
                                                                UserPreferences.CurrentCulture);
            }
            else
            {
                detail = new List<ComparisionActDetail>();
            }
            return View(mobile ? "_ComparisionActDetailMobile": "_ComparisionActDetail", detail);
            //new JsonResult { Data = detail, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
