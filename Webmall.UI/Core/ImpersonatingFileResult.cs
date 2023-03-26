using System;
using System.Web;
using System.Web.Mvc;
using SimpleImpersonation;
using log4net;
using log4net.Config;
using Webmall.Model;

namespace Webmall.UI.Core
{
    public class ImpersonatingFileResult : FilePathResult
    {
        private static ILog Log { get; } = LogManager.GetLogger(typeof(ImpersonatingFileResult));
        private static void InitializeLogger() { XmlConfigurator.Configure(); }

        static ImpersonatingFileResult() {
            InitializeLogger();
        }

        private readonly string impersonationSettings;
        public ImpersonatingFileResult(string fileName, string contentType, string fileDownloadName, string impersonationSettings )
            : base(fileName, contentType)
        {
            this.FileDownloadName = fileDownloadName;
            this.impersonationSettings = impersonationSettings;
        }


        protected override void WriteFile(HttpResponseBase response)
        {
            var impSettings = impersonationSettings;
            var arr = impSettings.Split(";");
            var logonType = (LogonType)int.Parse(arr[3]);

            var credentials = new UserCredentials(arr[0], arr[1], arr[2]);

            try
            {
                Impersonation.RunAsUser(credentials, logonType, () =>
                {
                    response.WriteFile(FileName); response.Flush(); response.End();

                });
            }
            catch (Exception e )
            {

                Log.Error("Ошибка отправки файла" , e);
                throw e;
            }

            
            // TODO : Rollback impersonation
        }
    }
}
