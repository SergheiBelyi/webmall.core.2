using System.Web.Mvc;

namespace Webmall.UI.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Show()
        {
            if (!TempData.ContainsKey("Message") || string.IsNullOrEmpty(TempData["Message"].ToString()))
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult BotDetected()
        {
            return View();
        }
    }
}
