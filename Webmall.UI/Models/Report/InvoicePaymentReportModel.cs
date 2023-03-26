using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class InvoicePaymentReportModel : ReportModel
    {
        public int OrderId
        {
            get;
            set;
        }

        public string Culture
        {
            get;
            set;
        }

        public override Dictionary<string, string> ReportParameters
        {
            get
            {
                base.ReportParameters.Clear();
                base.ReportParameters.Add("OrderId", OrderId.ToString());
                base.ReportParameters.Add("Culture", Culture);
                return base.ReportParameters;
            }
        }
    }
}