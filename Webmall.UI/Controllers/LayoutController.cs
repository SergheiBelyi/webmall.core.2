using System;
using System.Web.Mvc;
using Webmall.Model.Entities.Cms.PersonalMenu;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;
using Webmall.UI.Core.Helpers;
using Webmall.UI.ViewModel.Common;
using Webmall.UI.ViewModel.Garage;
using Webmall.UI.ViewModel.Layout;

namespace Webmall.UI.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ICmsRepository _cmsRepository;
        private readonly ICartRepository _cartRepository;

        public LayoutController(ICmsRepository cmsRepository, ICartRepository cartRepository)
        {
            _cmsRepository = cmsRepository;
            _cartRepository = cartRepository;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterModel
            {
                ContactInfo = _cmsRepository.GetContact(),
                Columns = _cmsRepository.GetFooterColumns(),
                SocialLinks = _cmsRepository.GetSocialLinks()
            };
            return View("Footer", model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult TopMenu(string culture)
        {
            var model = _cmsRepository.GetMenu();
            return View("TopMenu", model);
        }

        [ChildActionOnly]
        public ActionResult HeaderNav(bool mobile)
        {
            var model = _cmsRepository.GetHeaderNav();
            return View(mobile ? "HeaderNavMobile" : "HeaderNav", model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult HeaderBottom(string culture)
        {
            return View("HeaderBottom");
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult HeaderBottomMob(string culture)
        {
            return View("HeaderBottomMob");
        }

        [ChildActionOnly]
        public ActionResult MainInformer(string culture)
        {
            var cookieInformer = CookieHelper.GetCookieValue("informer");
            var dataNow = DateTime.Now;
            var isGross = SessionHelper.IsGross;
            var isRetail = SessionHelper.IsRetail;

            var model = _cmsRepository.GetInformerMain();
            if (model == null) return null;

            if (model.ForLanguage == true && (model.ForGrossOnly == isGross || model.ForRetailOnly == isRetail) && (model.DateStart <= dataNow && model.DateEnd >= dataNow))
            {
                if (!string.IsNullOrEmpty(cookieInformer) && model.Id == cookieInformer)
                    return null;

                return View("MainInformer", model);
            }

            return null;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult ContactHeader(string culture)
        {
            //var test = CultureInfo.CurrentCulture.Name;

            var model = _cmsRepository.GetContact();
            return View("ContactHeader", model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult ContactHeaderMob(string culture)
        {
            var model = new Header
            {
                ContactInfo = _cmsRepository.GetContact(),
                Menu = _cmsRepository.GetMenu()
            };
            return View("ContactHeaderMob", model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult StickyHeader(string culture)
        {
            var model = new Header
            {
                //ContactInfo = _cmsRepository.GetContact(),
                //Menu = _cmsRepository.GetMenu()
            };
            return View("StickyHeader", model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult StickyFooter(string culture)
        {

            return View("StickyFooter");
        }

        public ActionResult Authorized()
        {
            //if (SessionHelper.CurrentUser != null)
            //{ 
            //    SessionHelper.CurrentClient.Breefing.Clear();
            //    SessionHelper.Cart = _cartRepository.GetCart(UserPreferences.CurrentCulture, SessionHelper.CurrentUser); ;
            //}

            var user = SessionHelper.CurrentUser;

            var model = new Header
            {
                //ContactInfo = _cmsRepository.GetContact(),
                User = user,
                PersonalMenu = GetPersonalMenu(user)
            };

            return View("Authorized", model);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 60 * 10)]
        public ActionResult PersonalMenuList(string culture)
        {
            var user = SessionHelper.CurrentUser;
            var model = new PersonalMenuViewModel
            {
                //ContactInfo = _cmsRepository.GetContact(),
                //Menu = _cmsRepository.GetMenu()
                PersonalMenu = GetPersonalMenu(user)
            };
            return View("PersonalMenuList", model);
        }

        private MenuItem[] GetPersonalMenu(User user)
        {
            var categories = user.Categories;
            var personalMenu = _cmsRepository.GetPersonalMenu()[categories];
            return personalMenu;
        }

        [ChildActionOnly]
        public ActionResult UserCars()
        {
            var client = SessionHelper.CurrentClient;
            //var clientId = SessionHelper.CurrentClientId;
            var model = new GarageViewModel
            {
                Cars = SessionHelper.Garage,
                Client = client
            };

            return PartialView("Components/UserCars", model);
        }
    }
}
