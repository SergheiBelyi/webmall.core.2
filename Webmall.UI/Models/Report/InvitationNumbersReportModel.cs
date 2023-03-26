using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class InvitationNumbersReportModel : ReportModel
    {

        public string EventCode { get; set; }
        public int EventSeed { get; set; }
        public int Amount { get; set; }

        public override Dictionary<string, string> ReportParameters
        {
            get
            {
                base.ReportParameters.Clear();

                base.ReportParameters.Add("EventCode", EventCode);
                base.ReportParameters.Add("EventSeed", EventSeed.ToString());
                base.ReportParameters.Add("Amount", Amount.ToString());
              
                return base.ReportParameters;
            }
        }
    }

}