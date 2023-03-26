using System;
using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class PentupDemandReportModel : ReportModel
    {
        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }

        public int? ClientId
        {
            get;
            set;
        }

        public string Brand
        {
            get;
            set;
        }

        public override Dictionary<string, string> ReportParameters
        {
            get
            {
                base.ReportParameters.Clear();
                base.ReportParameters.Add("StartDate", StartDate.ToShortDateString());
                base.ReportParameters.Add("EndDate", EndDate.Date.AddDays(1).ToShortDateString());
                if (ClientId.HasValue)
                {
                    base.ReportParameters.Add("ClientId", ClientId.Value.ToString());
                }
                if (!string.IsNullOrEmpty(Brand))
                {
                    base.ReportParameters.Add("Brand", Brand);
                }
                return base.ReportParameters;
            }
        }
    }
}