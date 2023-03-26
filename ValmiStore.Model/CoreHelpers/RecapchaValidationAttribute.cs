using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace Webmall.Model.CoreHelpers
{

    /// <summary>
    /// Атрибут проверки капча
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class RecaptchaValidationAttribute : ActionFilterAttribute
    {
        #region Logger
        private static readonly ILog Log = LogManager.GetLogger(typeof(RecaptchaValidationAttribute));

        static RecaptchaValidationAttribute()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="filterContext">The filter filterContext.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var result = Validate(filterContext.HttpContext.Request);
            filterContext.RouteData.Values["captchaValid"] = result;
        }

        public bool Validate(HttpRequestBase request)
        {
            var response = request["g-recaptcha-response"];//Getting Response String Append to Post Method
            //Request to Google Server

            var client = new WebClient();
            var reply =
                client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={ConfigHelper.CaptchaSecretKey}&response={response}");

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            //when response is false check for the error message
            if (captchaResponse.Success) return true;

            if (captchaResponse.ErrorCodes == null || captchaResponse.ErrorCodes.Count <= 0) return false;

            var error = captchaResponse.ErrorCodes[0].ToLower();
            switch (error)
            {
                case ("missing-input-secret"):
                    Log.Error("The secret parameter is missing.");
                    break;
                case ("invalid-input-secret"):
                    Log.Error("The secret parameter is invalid or malformed.");
                    break;

                case ("missing-input-response"):
                    Log.Error("The response parameter is missing.");
                    break;
                case ("invalid-input-response"):
                    Log.Error("The response parameter is invalid or malformed.");
                    break;

                default:
                    Log.Error("Error occured. Please try again");
                    break;
            }
            return false;
        }
    }

    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
