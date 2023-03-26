using log4net;
using log4net.Config;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Webmall.UI.Controllers;
using Webmall.UI.Core;

namespace Webmall.UI
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Services : WebService
    {
        #region Logger

        private static readonly ILog Log = LogManager.GetLogger(typeof(Services));

        static Services()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        private static readonly string[] clearExclusion = { "mini-profiler-" };

        [WebMethod]
        public void ClearCache()
        {
            CheckSecurity();
            Log.Debug("Clear cache");

            CleanCacheKeys(GetCacheKeysToClean());

            SessionHelper.InvalidateValutes();
            ImagesController.ClearTimeStamps();
        }

        [WebMethod]
        public void ClearValuteCache()
        {
            CheckSecurity();
            Log.Debug("Clear valute cache");
            CleanCacheKeys(GetCacheKeysToClean("RefValutes"));

            SessionHelper.InvalidateValutes();
        }

        [WebMethod]
        public void InvalidateUser(string userId)
        {
            CheckSecurity();
            Log.Debug("InvalidateUser");
        }

        private List<string> GetCacheKeysToClean(string filter = null)
        {
            var result = new List<string>();
            foreach (DictionaryEntry objItem in Context.Cache)
            {
                string strName = objItem.Key.ToString();
                if (!clearExclusion.Any(i => strName.StartsWith(i)) && (filter == null || strName.StartsWith(filter)))
                {
                    result.Add(strName);
                }
            }
            return result;
        }

        private void CleanCacheKeys(List<string> keys)
        {
            foreach (var key in keys.OrderBy(i => i))
            {
                Log.Debug($"Clearing {key}");
                Context.Cache.Remove(key);
            }
        }

        private void CheckSecurity ()
        {
            if (Context.Request.Url.Host == "localhost")
                return;
            throw new System.Exception ("Access denied");
        }
    }
}