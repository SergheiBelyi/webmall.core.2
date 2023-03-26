using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Webmall.Model.Entities.User;
using Webmall.UI.Core;
using Webmall.UI.Models.AccessStatistics;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class AccessStatisticsController : Controller
    {
        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult Index(GridViewOptions options)
        {
            var model = new AccessStatisticsModel();
            if (options == null)
                options = new GridViewOptions();
            model.Items = MvcApplication.AccessStatistics.Values.AsGridView(ControllerContext, options, null);
            return View(model);
        }

        [GrantAccessFor((long)UserRoles.Admin)]
        public ActionResult Detail(string key, GridViewOptions options)
        {
            var model = new AccessStatisticsDetail();
            if (options == null)
                options = new GridViewOptions { SortColumn = "AccessTime", SortDirection = SortDirection.Descending };
            model.Items = MvcApplication.AccessStatistics[key].AsGridView(ControllerContext, options, null);
            return View(model);
        }

        [GrantAccessFor((long)UserRoles.Admin)]
        public FileResult SaveLog()
        {
            var fileName = MvcApplication.AccessStatistics.WriteToFile();

            return File (fileName, MimeMapping.GetMimeMapping(fileName), Path.GetFileName(fileName));
        }

        [GrantAccessFor((long)UserRoles.Admin)]
        public JsonResult Block(string key)
        {
            MvcApplication.AccessStatistics[key].IsBlocked = !MvcApplication.AccessStatistics[key].IsBlocked;
            MvcApplication.AccessStatistics[key].IsHuman = !MvcApplication.AccessStatistics[key].IsBlocked;
            return new JsonResult();
        }

    }
}
