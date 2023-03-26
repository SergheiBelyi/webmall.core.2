using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Webmall.Model;

namespace Webmall.UI.Core.Reports
{
    public class ReportResult : ActionResult
    {
        private readonly Dictionary<string, string> _exts;

        public ReportResult(ReportModel model)
        {
            _exts =  new Dictionary<string, string>
            {
                { "PDF", "pdf" }, 
                { "EXCEL", "xls" }
            };

            Model = model ?? throw new ArgumentNullException(nameof(model));
        }


        public ReportModel Model
        {
            get;
            private set;
        }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            var rview = new ReportViewer();
            rview.ServerReport.ReportServerUrl = new Uri(ConfigHelper.ReportServer);
            var username = ConfigHelper.RSUser;
            var password = ConfigHelper.RSPassword;
            var domain = ConfigHelper.RSDomain;

            var rpCredentials = new ReportViewerCredentials(username, password, domain);
            rview.ServerReport.ReportServerCredentials = rpCredentials;

            rview.ServerReport.ReportPath = Model.ReportPath;

            var paramList = (from p in Model.ReportParameters
                             let values = p.Value.Split(";")
                             select values.Length > 1 ? new ReportParameter(p.Key, values) : new ReportParameter(p.Key, p.Value)).ToList();

            try
            {
                rview.ServerReport.SetParameters(paramList);
                
                var bytes = rview.ServerReport.Render(Model.ReportFormat);
                var response = context.HttpContext.Response;
                
                response.ContentType = "application/" + Model.ReportFormat;
                response.OutputStream.Write(bytes, 0, bytes.Length);

                var headerValue = string.Format("{2}; filename=\"{0}.{1}\"", Model.ReportTitle, _exts[Model.ReportFormat], Model.ReportFormat == "PDF" ? "inline" : "attachment");
                context.HttpContext.Response.AddHeader("Content-Disposition", headerValue);
                context.HttpContext.Response.AddHeader("Content-Type", Model.ReportFormat == "PDF" ? "application/pdf" : "");
                //return File(result.ReportData, result.MimeType);
                response.End();
            }
            catch (Exception e)
            {
                // TODO Add Log
                //Log.ErrorFormat("Report Result: {0}", e);
            }
        }
    }
}
