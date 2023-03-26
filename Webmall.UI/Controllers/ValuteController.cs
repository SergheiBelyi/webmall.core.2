using System.Web.Mvc;
using Webmall.Model.Repositories.Abstract;
using Webmall.UI.Core;

namespace Webmall.UI.Controllers
{
    [Authorize]
    public class ValuteController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public ValuteController ()
        {
            // UserRepository = userRepository;
        }

        public void Change(string id)
        {
            SessionHelper.CurrentClient.CurrentValute = id;
        }
    }
}