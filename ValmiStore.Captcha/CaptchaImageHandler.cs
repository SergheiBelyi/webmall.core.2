using System;
using System.Web;
using System.Drawing;

namespace ValmiStore.Captcha
{
        /// <summary>
        /// Captcha image stream HttpModule. Retrieves CAPTCHA objects from cache, renders them to memory, 
        /// and streams them to the browser.
        /// </summary>
        /// <remarks>
        /// You must add the to your web.config:
        ///     <httpHandlers>
        ///             <add verb="GET" path="captcha.ashx" type="ManagedFusion.Web.Handlers.CaptchaImageHandler, ManagedFusion" />
        ///     </httpHandlers>
        /// </remarks>
        /// <seealso href="http://www.codinghorror.com">Original By Jeff Atwood</seealso>
        public class CaptchaImageHandler : IHttpHandler
        {
                #region IHttpHandler Members

                /// <summary>
                /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
                /// </summary>
                /// <value></value>
                /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
                public bool IsReusable
                {
                        get { return true; }
                }

                /// <summary>
                /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
                /// </summary>
                /// <param name="filterContext">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
                public void ProcessRequest(HttpContext context)
                {
                        // get the unique GUID of the captcha; this must be passed in via the querystring
                        string guid = context.Request.QueryString["guid"];
                        CaptchaImage ci = CaptchaImage.GetCachedCaptcha(guid);

                        if (String.IsNullOrEmpty(guid) || ci == null)
                        {
                                context.Response.StatusCode = 404;
                                context.Response.StatusDescription = "Not Found";
                                context.Response.End();
                                return;
                        }

                        using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                        {
                            using (Bitmap b = ci.RenderImage())
                            {
                                b.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                                stream.WriteTo(HttpContext.Current.Response.OutputStream);
                            }
                        }

                        // write the image to the HTTP output stream as an array of bytes

                        context.Response.ContentType = "image/png";
                        context.Response.StatusCode = 200;
                        context.Response.StatusDescription = "OK";
                        context.Response.End();
                }

                #endregion
        }
}