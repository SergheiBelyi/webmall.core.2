using System;
using System.Web.Mvc;

namespace ValmiStore.Captcha
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class CaptchaValidationAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptchaCheckAttribute"/> class.
        /// </summary>
        public CaptchaValidationAttribute()
            : this("captcha") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaptchaCheckAttribute"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        public CaptchaValidationAttribute(string field)
        {
            Field = field;
        }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public string Field { get; private set; }

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="filterContext">The filter filterContext.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // make sure no values are getting sent in from the outside
            if (filterContext.ActionParameters.ContainsKey("captchaValid"))
                filterContext.ActionParameters["captchaValid"] = null;

            // get the guid from the post back
            string guid = filterContext.HttpContext.Request.Form["captcha-guid"];


            filterContext.RouteData.Values["captchaValid"] =
            filterContext.ActionParameters["captchaValid"] = false;

            // check for the guid because it is required from the rest of the opperation
            if (String.IsNullOrEmpty(guid)) return;

            // get values
            CaptchaImage image = CaptchaImage.GetCachedCaptcha(guid);
            if (image == null) return;

            string actualValue = filterContext.HttpContext.Request.Form[Field];
            string expectedValue = image.Text;

            // removes the captch from cache so it cannot be used again
            filterContext.HttpContext.Cache.Remove(guid);

            // validate the captch
            filterContext.RouteData.Values["captchaValid"] = 
            filterContext.ActionParameters["captchaValid"] =
                    !String.IsNullOrEmpty(actualValue)
                    && !String.IsNullOrEmpty(expectedValue)
                    && String.Equals(actualValue, expectedValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}