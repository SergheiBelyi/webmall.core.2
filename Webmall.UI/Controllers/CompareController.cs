using System.Linq;
using System.Web.Mvc;
using Webmall.UI.Core;
using Webmall.UI.Models.WareComparision;

namespace Webmall.UI.Controllers
{
    public class CompareController : Controller
    {

        public ActionResult Index()
        {
            var model = new ComparisionModel();

            var list = SessionHelper.ComparisionList;
            model.ComparisionList = list;

            if (list == null || list.Count < 2)
                return Redirect(Url.Content("~/"));

            ViewBag.Title = ViewRes.SharedResources.WareComparision;

            //if (list.Count == 0)
            //    list.AddRange(new ComparisionList
            //                            {
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32956329, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32964142, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32956329, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32964142, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32956329, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                              repository.GetWare(UserPreferences.CurrentCulture, 32376182, SessionHelper.CurrentClientId, SessionHelper.CurrentWarehouseId),
            //                            });
            //foreach (var item in model.ComparisionList)
            //{
            //    item.Properties = repository.GetWareProperties(UserPreferences.CurrentCulture, item.Id, null);
            //}

            return View(model);
        }

        public ActionResult Remove(string id)
        {
            var item = SessionHelper.ComparisionList.FirstOrDefault(i => i.Id == id);
            if (item != null)
                SessionHelper.ComparisionList.Remove(item);
            //return Redirect(Request.UrlReferrer.AbsoluteUri);
            return RedirectToAction("Index");
        }

    }
}
