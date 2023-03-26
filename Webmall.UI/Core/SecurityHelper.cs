using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Webmall.Model.Entities.User;

namespace Webmall.UI.Core
{
    public class SecurityHelper
    {
        /// <summary>
        /// Возвращает наличие у текущего пользователя хотя бы одной из ролей
        /// </summary>
        /// <param name="roleTypes">Флаговый набор ролей</param>
        /// <returns>true - пользователь имеет одну из ролей, false - нет</returns>
        public static bool IsUserInRoleTypes(long roleTypes)
        {
            if (SessionHelper.CurrentUser == null) return false;
            return (SessionHelper.CurrentUser.Roles & roleTypes) > 0;
        }

        /// <summary>
        /// Возвращает наличие у текущего пользователя заданной роли
        /// </summary>
        /// <param name="role">Роль</param>
        /// <returns>true - пользователь имеет одну из ролей, false - нет</returns>
        public static bool UserHasRole(UserRoles role)
        {
            return IsUserInRoleTypes((long)role);
        }

        internal static void AccessDenied(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Controller.TempData["Message"] = "Доступ к данному разделу сайта Вам запрещен. Пожайлуста обратитесь к администратору портала для разрешения данной проблемы. Спасибо за понимание.";
                filterContext.Controller.TempData["Title"] = "Доступ запрещен";
                filterContext.RedirectToAction("Show", "Message");
            }
            else FormsAuthentication.RedirectToLoginPage();
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class GrantAccessFor: ActionFilterAttribute
    {
        private readonly long _allowedRoles;
        public GrantAccessFor(long allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!SecurityHelper.IsUserInRoleTypes(_allowedRoles)) SecurityHelper.AccessDenied(filterContext);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class RefuseAccessFor : ActionFilterAttribute
    {
        private readonly long _refusedRoles;
        public RefuseAccessFor(long refusedRoles)
        {
            _refusedRoles = refusedRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SecurityHelper.IsUserInRoleTypes(_refusedRoles)) SecurityHelper.AccessDenied(filterContext);
        }
    }
}