using System.Collections.Generic;

namespace Webmall.UI.Core.Reports
{
    public class ReportModel
    {
        public ReportModel()
        {
            ReportParameters = new Dictionary<string, string>();
        }

        public string ReportFormat { get; set; }

        public string ReportTitle { get; set; }

        public string ReportPath { get; set; }

        public virtual Dictionary<string, string> ReportParameters { get; private set; }
    }
}