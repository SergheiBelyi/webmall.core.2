using System.Web.Mvc;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.UI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ICmsRepository _cmsRepository;

        public ArticleController(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public ActionResult Index(string id)
        {
            var model = _cmsRepository.GetArticle(id);
            if (model == null)
                return new HttpNotFoundResult();
            ViewBag.HeaderTitle =  model.Title.ToString();
            ViewBag.Description = model.Description.ToString();
            ViewBag.Keywords = model.Keywords.ToString();
            return View(model);
        }
    }
}
