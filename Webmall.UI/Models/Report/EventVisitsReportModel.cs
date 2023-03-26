using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class EventVisitsReportModel : ReportModel
    {

        public int EventId { get; set; }
        public string EventName { get; set; }

        public override Dictionary<string, string> ReportParameters
        {
            get
            {
                base.ReportParameters.Clear();

                base.ReportParameters.Add("EventId", EventId.ToString());
                base.ReportParameters.Add("EventName", EventName);
              
                return base.ReportParameters;
            }
        }
    }

}