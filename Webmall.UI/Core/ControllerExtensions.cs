using System.Web.Mvc;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Core
{
    public static class ControllerExtensions
    {
        public static ReportResult Report(this Controller controller, ReportModel model)
        {
            return new ReportResult(model);
        }
    }
}