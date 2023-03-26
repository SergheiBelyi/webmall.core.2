using System.Text;
using System.Web.Caching;
using ValmiStore.Captcha;

// ReSharper disable CheckNamespace
namespace System.Web.Mvc
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// 
    /// </summary>
    public static class HtmlHelperExtension
    {
        /// <summary>
        /// Ifs the specified response.
        /// </summary>
        /// <param name="helper"> </param>
        /// <param name="condition">if set to <see langword="true"/> [condition].</param>
        /// <param name="function">The function.</param>
        /// <returns></returns>
        public static If<string> If(this HtmlHelper helper, bool condition, Func<string> function)
        {
            return new If<string>(condition, function);
        }

        /// <summary>
        /// Ifs the specified helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="condition">if set to <see langword="true"/> [condition].</param>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static If<string> If(this HtmlHelper helper, bool condition, string response)
        {
            return new If<string>(condition, response);
        }

        /// <summary>
        /// Switches the specified response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"> </param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static Switch<T, string> Switch<T>(this HtmlHelper helper, T type)
        {
            return new Switch<T, string>(type);
        }

        /// <summary>
        /// Captchas the text box.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string CaptchaTextBox(this HtmlHelper helper, string name)
        {
            return String.Format(@"<input type=""text"" id=""{0}"" name=""{0}"" value="""" maxlength=""{1}"" autocomplete=""off"" />",
                            name,
                                ValmiStore.Captcha.CaptchaImage.TextLength
                            );

        }

        /// <summary>
        /// Generates the captcha image.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <returns>
        /// Returns the <see cref="Uri"/> for the generated <see cref="CaptchaImage"/>.
        /// </returns>
        public static HtmlString CaptchaImage(this HtmlHelper helper, int height, int width)
        {
            CaptchaImage image = new CaptchaImage
            {
                Height = height,
                Width = width,
            };
            
            HttpRuntime.Cache.Add(
                    image.UniqueId,
                    image,
                    null,
                    DateTime.Now.AddDays(ValmiStore.Captcha.CaptchaImage.CacheTimeOut),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.NotRemovable,
                    null);

            StringBuilder stringBuilder = new StringBuilder(256);
            stringBuilder.Append("<input type=\"hidden\" name=\"captcha-guid\" value=\"");
            stringBuilder.Append(image.UniqueId);
            stringBuilder.Append("\" />");
            stringBuilder.AppendLine();
            stringBuilder.Append("<img src=\"");

            UrlHelper url = new UrlHelper(helper.ViewContext.RequestContext);
            stringBuilder.Append(url.Content(@"~/captcha.ashx") + "?guid=" + image.UniqueId);
            stringBuilder.Append("\" alt=\"CAPTCHA\" width=\"");
            stringBuilder.Append(width);
            stringBuilder.Append("\" height=\"");
            stringBuilder.Append(height);
            stringBuilder.Append("\" />");

            return new HtmlString(stringBuilder.ToString());
        }
    }
}