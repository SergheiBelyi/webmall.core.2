using System.Net;
using System.Security.Principal;
using Microsoft.Reporting.WebForms;

namespace Webmall.UI.Core.Reports
{
    class ReportViewerCredentials : IReportServerCredentials
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _domain;

        public ReportViewerCredentials(string userName, string password, string domain)
        {
            _userName = userName;
            _password = password;
            _domain = domain;

        }


        public WindowsIdentity ImpersonationUser
        {
            get
            {
                //return null;
                return WindowsIdentity.GetCurrent();
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {

                return new NetworkCredential(_userName, _password, _domain);

            }
        }

        public bool GetFormsCredentials(out Cookie authCookie,
                out string userName, out string password,
                out string authority)
        {
            authCookie = null;
            userName = _userName;
            password = _password;
            authority = _domain;

            // Not using form credentials   
            return false;
        }
    }
}
