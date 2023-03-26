using System.Linq;
using System.Web.Mvc;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.UI.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ICmsRepository _cmsRepository;

        public ReviewController(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        public ActionResult Index(string id)
        {
            var lowerId = id.ToLower();
            var model = _cmsRepository.GetCustomerReviews().FirstOrDefault(i=>i.Slug == lowerId);
            if (model == null)
                return new HttpNotFoundResult();
            ViewBag.HeaderTitle =  model.Title.ToString();
            ViewBag.Description = model.Description.ToString();
            ViewBag.Keywords = model.Keywords.ToString();
            return View(model);
        }
    }
}
