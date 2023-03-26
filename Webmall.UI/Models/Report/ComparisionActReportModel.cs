using System;
using System.Collections.Generic;
using Webmall.UI.Core.Reports;

namespace Webmall.UI.Models.Report
{
    public class ComparisionActReportModel : ReportModel
    {
        public string KagId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Culture { get; set; }

        public string DocTypeId { get; set; }

        public string PaymentFormId { get; set; }

        public string PaymentStatusId { get; set; }

        public bool Detailed { get; set; }

        //public override Dictionary<string, string> ReportParameters
        //{
        //    get
        //    {
        //        base.ReportParameters.Clear();

        //        base.ReportParameters.Add("KagId", KagId);
        //        base.ReportParameters.Add("StartDate", StartDate.ToShortDateString());
        //        base.ReportParameters.Add("EndDate", EndDate.ToShortDateString());
        //        if (!string.IsNullOrEmpty(Culture))
        //        {
        //            base.ReportParameters.Add("Culture", Culture);
        //        }
        //        if (!string.IsNullOrEmpty(DocTypeId))
        //        {
        //            base.ReportParameters.Add("DocTypeId", DocTypeId);
        //        }
        //        if (!string.IsNullOrEmpty(PaymentFormId))
        //        {
        //            base.ReportParameters.Add("PaymentFormId", PaymentFormId);
        //        }
        //        if (!string.IsNullOrEmpty(PaymentStatusId))
        //        {
        //            base.ReportParameters.Add("PaymentStatusId", PaymentStatusId);
        //        }

        //        return base.ReportParameters;
        //    }
        //}
    }
}