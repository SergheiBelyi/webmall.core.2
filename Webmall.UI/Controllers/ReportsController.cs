using System;
using System.IO;
using System.Web.Mvc;
using Webmall.UI.Core;
using Webmall.UI.Core.Reports;
using Webmall.UI.Models.Report;
using ViewRes;
using System.Globalization;
using Webmall.UI.Core.Helpers;
using Webmall.Model;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IReportsRepository _reportsRepository;

        public ReportsController(IReportsRepository reportsRepository)
        {
            this._reportsRepository = reportsRepository;
        }

        [HttpGet]
        public FileResult InvoicePayment(string orderId, string reportFormat = "pdf")
        {
            var reportFormatExt = reportFormat?.ToLower().Replace("excel", "xlsx");
            var buffer = _reportsRepository.GetInvoice(SessionHelper.CurrentClientId, orderId, reportFormatExt);
            var result = new FileStreamResult(new MemoryStream(buffer), "application/" + reportFormat) { FileDownloadName = orderId + "."+ reportFormatExt };
            return result;
        }

        //[HttpGet]
        //public ReportResult InvoicePayment(int orderId, string reportFormat = "PDF")
        //{
        //    var culture = UserPreferences.CurrentCulture;

        //    var model = new InvoicePaymentReportModel
        //    {
        //        OrderId = orderId,
        //        Culture = culture,
        //        ReportFormat = reportFormat,
        //        ReportPath = ConfigHelper.InvoiceReportName,
        //        ReportTitle = string.Format("Order Nr.{0}", orderId)
        //    };

        //    return this.Report(model);
        //}

        //[HttpPost]
        //public ReportResult ComparisionAct(ComparisionActReportModel model)
        //{
        //    model.ReportFormat = "EXCEL";

        //    model.ReportPath = ConfigHelper.ComparisionActReportName + (model.Detailed ? "Detailed" : "");
        //    model.ReportTitle = @SharedResources.ComparisionAct + (model.Detailed ? $" ({SharedResources.Details})" : "");
        //    if (model.PaymentFormId == -1) model.PaymentFormId = null;
        //    if (model.PaymentStatusId == -1) model.PaymentStatusId = null;
        //    if (model.DocTypeId == -1) model.DocTypeId = null;
        //    model.KagId = SessionHelper.CurrentClientId.ToString();
        //    model.Culture = UserPreferences.CurrentCulture;

        //    return this.Report(model);
        //}

        [HttpGet]
        public ActionResult ComparisionAct(ComparisionActReportModel model, string reportFormat = "excel")
        {
            //var reportFormat = "excel";
            var reportFormatExt = reportFormat.ToLower().Replace("excel", "xlsx");

            var startDate = DateTime.TryParseExact(model.StartDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var minDateValue) ? minDateValue 
                : DateTime.TryParseExact(model.StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out minDateValue) ? minDateValue 
                    : new DateTime(DateTime.Now.Year, 1, 1);
            var endDate = DateTime.TryParseExact(model.EndDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var maxDateValue) ? maxDateValue
                : DateTime.TryParseExact(model.EndDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out maxDateValue) ? maxDateValue
                    : DateTime.Now;

            var filter = CommonHelpers.GetFilter(Request.Params);

            var buffer = _reportsRepository.GetComparisionAct(SessionHelper.CurrentClientId, "ru-RU", model.Detailed, "", model.DocTypeId ?? "", 
                endDate.ToString("yyyy-MM-dd"), startDate.ToString("yyyy-MM-dd"), reportFormatExt, filter);
            if (buffer == null)
            {
                TempData["Message"] = SharedResources.ComparisionActErrorMessage;
                return RedirectToAction("Show", "Message");
            }
            var result = new FileStreamResult(new MemoryStream(buffer), "application/" + reportFormat) { FileDownloadName = "Comparision Act" + "." + reportFormatExt };
            return result;
        }

        [HttpGet]
        public ReportResult EventTicket (EventTicketReportModel model)
        {
            model.ReportFormat = "PDF";
            model.ReportPath = ConfigHelper.EventTicketReportName;
            model.ReportTitle = "Tickets"; // ViewRes.SharedResources.EventTicket;

            //if (model.PaymentFormId == -1) model.PaymentFormId = null;
            //if (model.PaymentStatusId == -1) model.PaymentStatusId = null;
            //if (model.DocTypeId == -1) model.DocTypeId = null;
            //model.KagId = SessionHelper.CurrentClientId.ToString();
            //model.Culture = UserPreferences.CurrentCulture;

            return this.Report(model);
        }

        [HttpGet]
        public ReportResult TransmissionAct(int orderId)
        {
            var culture = UserPreferences.CurrentCulture;

            var model = new TransmissionActReportModel
            {
                OrderId = orderId,
                Culture = culture,
                IsOperative = SessionHelper.CurrentClient.IsOperative,
                ReportFormat = "PDF",
                ReportPath = ConfigHelper.TransmissionActReportName,
                ReportTitle = $"Act for order Nr.{orderId}"
            };

            return this.Report(model);
        }
    }
}
