using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using Webmall.Model;
using Webmall.Model.Abstract;
using Webmall.Model.Entities.Catalog;

namespace Webmall.UI.Core
{
    public static class Extensions
    {
        #region Html Buttons

        public static HtmlString SubmitButton(this HtmlHelper htmlHelper, string value)
        {
            return SubmitButton(htmlHelper, value, null);
        }

        public static HtmlString SubmitButton(this HtmlHelper htmlHelper, string value, object attributes)
        {
            var attrs = new RouteValueDictionary(attributes) {{"type", "submit"}};
            if (attrs.ContainsKey("class"))
                attrs["class"] = (string)attrs["class"] + " button-submit";
            else
                attrs.Add("class", "button-submit");
            return Button(htmlHelper, value, attrs);
        }

        public static HtmlString SubmitInput(this HtmlHelper htmlHelper, string value, object attributes = null, bool isActive = true)
        {
            var attrs = new RouteValueDictionary(attributes) { { "type", "submit" }, { "value", value } };
            if (attrs.ContainsKey("class"))
                attrs["class"] = (string)attrs["class"] + " button-submit";
            else
                attrs.Add("class", "button-submit");
            var writer = new HtmlTextWriter(new StringWriter());
            foreach (var attr in attrs)
                writer.AddAttribute(attr.Key, attr.Value.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }

        public static HtmlString Button(this HtmlHelper htmlHelper, string value, object attributes)
        {
            return Button(htmlHelper, value, new RouteValueDictionary(attributes));
        }

        public static HtmlString Button(this HtmlHelper htmlHelper, string value, RouteValueDictionary attributes)
        {
            var writer = new HtmlTextWriter(new StringWriter());
            if (attributes == null)
                attributes = new RouteValueDictionary();
            
            if (!attributes.ContainsKey("type"))
                attributes.Add("type", "button");

            foreach (var attr in attributes)
                    writer.AddAttribute(attr.Key, attr.Value.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Button);

            var wSspan = new HtmlTextWriter(new StringWriter());
            //wSspan.RenderBeginTag(HtmlTextWriterTag.Span);
            wSspan.Write(value);
            //wSspan.RenderEndTag();

            writer.Write(wSspan.InnerWriter.ToString());
            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }

        #endregion

        #region GroupMenuElement

        static readonly int MaxDepth = 3;
        static readonly string[] LI_ClassNames = { "main-nav__item", "main-nav__sub-item", "main-nav__tertiary-item" };
        static readonly string[] A_ClassNames = { "main-nav__link", "main-nav__sub-link", "main-nav__tertiary-link" };
        static readonly string[] UL_ClassNames = { "main-nav__list", "main-nav__sub-list", "main-nav__tertiary-container" };

        static string ClassNameForLI(int lvl)
        {
            if (lvl < 1) return "";
            if (lvl > MaxDepth) lvl = MaxDepth;
            return LI_ClassNames[lvl-1];
        }
        static string ClassNameForUL(int lvl)
        {
            if (lvl < 1) return "";
            if (lvl > MaxDepth) lvl = MaxDepth;
            return UL_ClassNames[lvl - 1];
        }
        static string ClassNameForA(int lvl)
        {
            if (lvl < 1) return "";
            if (lvl > MaxDepth) lvl = MaxDepth;
            return A_ClassNames[lvl - 1];
        }

        public static HtmlString GroupMenuElements(this HtmlHelper htmlHelper, IEnumerable<ValmiStore.Model.Entities.Group> groupsList, string parentLink, WebViewPage page)
        {
            var tiresGroup = ConfigHelper.TiresGroup;
            var writer = new HtmlTextWriter(new StringWriter());

            foreach (var group in groupsList.Where(i=>i.Url != tiresGroup))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.AddAttribute("href", page.Url.Content("~/" + parentLink + group.Url));
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                if (group.Children.Any())
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);
                    writer.Write(group.Title);
                    writer.RenderEndTag(); // Span
                    writer.RenderEndTag(); // A
                    writer.RenderBeginTag(HtmlTextWriterTag.Ul);
                    writer.Write(GroupMenuElements(htmlHelper, group.Children, parentLink, page));
                    writer.RenderEndTag();
                }
                else
                {
                    writer.Write(group.Title);
                    writer.RenderEndTag(); // A
                }

                writer.RenderEndTag();
            }


            //if (attributes != null)
            //{
            //    foreach (var attr in attributes)
            //        writer.AddAttribute(attr.Key, attr.Value.ToString());
            //}
            //writer.RenderBeginTag(HtmlTextWriterTag.Button);

            //var wSspan = new HtmlTextWriter(new StringWriter());
            //wSspan.RenderBeginTag(HtmlTextWriterTag.Span);
            //wSspan.Write(value);
            //wSspan.RenderEndTag();

            //writer.Write(wSspan.InnerWriter.ToString());
            //writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }

        public static HtmlString GroupMenuElements(this HtmlHelper htmlHelper, IEnumerable<Group> groupsList, string parentLink, WebViewPage page, int level)
        {
            var tiresGroup = ConfigHelper.TiresGroup;
            var writer = new HtmlTextWriter(new StringWriter());

            foreach (var group in groupsList.Where(i => i.Url != tiresGroup))
            {
                writer.AddAttribute("class", ClassNameForLI(level));
                writer.RenderBeginTag(HtmlTextWriterTag.Li);

                if (!string.IsNullOrEmpty(group.Name))
                {
                    writer.AddAttribute("href", page.Url.Content("~/" + parentLink + group.Url));
                    writer.AddAttribute("class", ClassNameForA(level));
                    writer.RenderBeginTag(HtmlTextWriterTag.A);

                    writer.Write(group.Name);

                    if (group.SubGroups.Any() && level == 1)
                    {
                        writer.AddAttribute("class", "icon icon-chevron-right main-nav--icon");
                        writer.RenderBeginTag("svg");
                        writer.AddAttribute("href",
                            page.Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-right"));
                        writer.RenderBeginTag("use");
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }

                    writer.RenderEndTag(); // A
                }

                if (group.SubGroups.Any())
                {
                    if (level == 1)
                    {
                        writer.AddAttribute("class", "main-nav__sub-container");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    }

                    var className = ClassNameForUL(level + 1);
                    /*if (group.SubGroups.Count() > 1)
                    {
                        className += $" {className}--cols";
                    }*/
                    writer.AddAttribute("class", className);
                    writer.RenderBeginTag(HtmlTextWriterTag.Ul); // UL
                    writer.Write(GroupMenuElements(htmlHelper, group.SubGroups, parentLink, page, level + 1));
                    writer.RenderEndTag(); // UL

                    if (level == 1)
                    {
                        writer.RenderEndTag(); // div
                    }
                    
                }

                writer.RenderEndTag(); // LI
            }

            return new HtmlString(writer.InnerWriter.ToString());
        }

        #endregion



        public static bool IsCurrentPage(this UrlHelper helper, string url)
        {
            var pageUrl = helper.RequestContext.RouteData.Values["PageUrl"];
            if (pageUrl == null) return false;
            return string.Compare(url, pageUrl.ToString(), true, CultureInfo.InvariantCulture) == 0;
        }

        public static string RouteUrlEx(this UrlHelper helper, object routeValues)
        {
            var filePath = helper.RequestContext.HttpContext.Request.FilePath;
            //
            var props = routeValues.GetType().GetProperties();
            var nv = new NameValueCollection(helper.RequestContext.HttpContext.Request.QueryString);
            foreach (var pr in props)
                nv.Add(pr.Name, HttpUtility.HtmlEncode(pr.GetValue(routeValues, null)));
            //
            if (nv.Count == 0) return filePath;
            //
            var builder = new StringBuilder(filePath);
            builder.Append('?');
            builder.Append(CreateQueryString(nv));
            return builder.ToString();
        }

        public static string CreateQueryString(NameValueCollection values)
        {
            var builder = new StringBuilder();
            //
            foreach (string key in values.Keys)
                foreach (var value in values.GetValues(key))
                    builder.AppendFormat("&amp;{0}={1}", key, HttpUtility.HtmlEncode(value));
            //
            return builder.ToString().Substring(5);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                action(item, i++);
            }
        }

        public static T FirstOrDefaultInTree<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : ITreeComposite<T>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var result = default(T);
            foreach (var item in source)
            {

                if (predicate.Invoke(item))
                    return item;
                result = item.Children.FirstOrDefaultInTree(predicate);
                if (result != null) break;
            }
            return result;
        }

        public static IEnumerable<T> Ancestors<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : ITreeComposite<T>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var result = new List<T>();
            foreach (var item in source)
            {
                if (predicate.Invoke(item))
                {
                    result.Add(item);
                    return result.AsEnumerable();
                }
                var rs = item.Children.Ancestors(predicate);
                if (rs.Any())
                {
                    result.Add(item);
                    result.AddRange(rs);
                }
            }
            return result;
        }

        public static bool ContainsDeep<T>(this T rootItem, T item) where T : ITreeComposite<T>
        {
            //Func<T, bool> predicate
            if (rootItem == null)
            {
                throw new ArgumentNullException("rootItem");
            }
            if (item == null) return false;
            if (item.Equals(rootItem)) return true;
            var result = false;
            foreach (var child in rootItem.Children)
            {
                if (child.Equals(item))
                    return true;
#pragma warning disable 665
                if (result = ContainsDeep(child, item)) break;
#pragma warning restore 665
            }
            return result;
        }

        public static IEnumerable<T> CloneCollection<T>(this IEnumerable<T> source)
        {
            var result = new List<T>();
            var enm = source.GetEnumerator();
            while (enm.MoveNext())
                result.Add(enm.Current.Clone());
            return result.AsEnumerable();
        }

        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException(@"The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string)helper.ViewContext.RouteData.Values["action"];

            return currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsCurrentController(this HtmlHelper helper, string controllerName)
        {
            var currentControllerName = (string)helper.ViewContext.RouteData.Values["controller"];

            return currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase);
        }

        public static HtmlString PageLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl, bool useScript = true)
        {
            // TODO Кандидат на удаление
            var diff = 1;
            var result = new StringBuilder();
            var totalPages2 = totalPages;

            if (currentPage < 1)
                currentPage = 1;

            if ((currentPage + diff) < totalPages)
                totalPages = currentPage + diff;
            var startPage = 1;
            if ((currentPage - diff) > startPage)
                startPage = currentPage - diff;

            if ((currentPage - diff) > 1)
            {
                var tag3 = new TagBuilder("a");
                tag3.Attributes.Add("href", pageUrl(1));
                tag3.InnerHtml = "1";
                if (useScript) tag3.Attributes["onclick"] = String.Format("return gotoPage(this, {0});", 1);
                result.AppendLine(tag3.ToString());
            }

            if ((currentPage - (diff + 1)) > 1)
            {
                var tag2 = new TagBuilder("a");
                tag2.Attributes.Add("href", pageUrl(currentPage - (diff + 1)));
                tag2.InnerHtml = "...";
                if (useScript) tag2.Attributes["onclick"] = String.Format("return gotoPage(this, {0});", currentPage - (diff + 1));
                result.AppendLine(tag2.ToString());
            }

            for (var i = startPage; i <= totalPages; i++)
            {
                var tag = new TagBuilder("a");
                tag.Attributes.Add("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                    tag.AddCssClass("pageSelected");
                if (useScript) tag.Attributes["onclick"] = String.Format("return gotoPage(this, {0});", i);
                result.AppendLine(tag.ToString());
            }

            if ((currentPage + (diff + 1)) < totalPages2)
            {
                var tag2 = new TagBuilder("a");
                tag2.Attributes.Add("href", pageUrl(currentPage + (diff + 1)));
                tag2.InnerHtml = "...";
                if (useScript) tag2.Attributes["onclick"] = String.Format("return gotoPage(this, {0});", currentPage + (diff + 1));
                result.AppendLine(tag2.ToString());
            }

            if ((currentPage + diff) < totalPages2)
            {
                var tag3 = new TagBuilder("a");
                tag3.Attributes.Add("href", pageUrl(totalPages2));
                tag3.InnerHtml = totalPages2.ToString();
                if (useScript) tag3.Attributes["onclick"] = String.Format("return gotoPage(this, {0});", totalPages2);
                result.AppendLine(tag3.ToString());
            }
            return new HtmlString(result.ToString());
        }

        /// <summary>
        /// Redirects to action.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void RedirectToAction(this ControllerContext filterContext, string actionName)
        {
            if (String.IsNullOrEmpty(actionName))
                throw new ArgumentNullException("actionName");

            var values = new RouteValueDictionary {{"action", actionName}};

            RedirectToAction(filterContext, values);
        }

        /// <summary>
        /// Redirects to action.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        public static void RedirectToAction(this ControllerContext filterContext, string actionName, string controllerName)
        {
            if (String.IsNullOrEmpty(actionName))
                throw new ArgumentNullException("actionName");

            if (String.IsNullOrEmpty(controllerName))
                throw new ArgumentNullException("controllerName");

            var values = new RouteValueDictionary {{"action", actionName}, {"controller", controllerName}};

            RedirectToAction(filterContext, values);
        }

        /// <summary>
        /// Redirects to action.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="values">The values.</param>
        public static void RedirectToAction(this ControllerContext filterContext, RouteValueDictionary values)
        {
            var virtualPath = RouteTable.Routes.GetVirtualPath(filterContext.RequestContext, values);

            string url = null;
            if (virtualPath != null) url = virtualPath.VirtualPath;

            filterContext.HttpContext.Response.Redirect(url);
        }

        public static string GetFullHtmlFieldNameFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            var fieldName = ExpressionHelper.GetExpressionText(expression);

            var htmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);

            return htmlFieldName;
        }

        public static bool IsSearchBot(this HttpRequestBase request)
        {
            var agent = request.Headers["User-Agent"];

            return agent == null || agent.Contains("Googlebot") || agent.Contains("Yandex") 
                //|| agent.Contains("Mozilla")
                ;
        }

        /// <summary>
        /// Формирует Html-строку на базе строки с параметрами
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="value"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHtmlString Raw(this HtmlHelper helper, string value, params object[] args)
        {
            return helper.Raw(string.Format(value, args));
        }
        
        public static byte[] ToByteArray(this string text)
        {
            return new UTF8Encoding().GetBytes(text);
        }
    }
}