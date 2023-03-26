using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Models;

namespace Webmall.UI.Controllers
{
    public class OriginalCatalogController : Controller
    {
        private readonly ICmsRepository _cmsRepository;

        public OriginalCatalogController (ICmsRepository cmsRepository)
        {

            _cmsRepository = cmsRepository;
        }

        public ActionResult Index(string id)
        {
            var model = new ExternalCatalogModel
            {
                Catalog = _cmsRepository.GetExternalCatalog(),
                SelectedItemId = id,
            };
            return View(model);
        }

        public ActionResult Show(int id)
        {
            var category = _cmsRepository.GetExternalCatalog().FirstOrDefault(i => i.Items.Any(j => j.Id == id));
            if (category != null)
            {
                var model = category.Items.First(i => i.Id == id);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShowExt(string url)
        {
            return Redirect(url);
        }
    }
}
