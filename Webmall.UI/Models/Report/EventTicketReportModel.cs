using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class EventTicketReportModel : ReportModel
    {

        public string KagId { get; set; }

        public string EventId { get; set; }

        public string Guid { get; set; }

        public override Dictionary<string, string> ReportParameters
        {
            get
            {
                base.ReportParameters.Clear();

                base.ReportParameters.Add("KagId", KagId ?? "0");
                base.ReportParameters.Add("EventId", EventId);
                base.ReportParameters.Add("Guid", Guid ?? ".");
                return base.ReportParameters;
            }
        }
    }

}