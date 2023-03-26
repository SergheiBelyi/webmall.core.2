using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webmall.UI.Core
{
    public static class GridViewHelper
    {
        public static GridViewModel<T> AsGridView<T>(this IEnumerable<T> list, ControllerContext controllerContext, GridViewOptions options, int? totalRows, string defaultSortColumn = null, bool allowPagging = true)
        {
            var result = new GridViewModel<T> {Context = options.Context = controllerContext, AllowPagging = allowPagging, PageSize = options.PageSize};

            IQueryable<T> query = list.AsQueryable();

            if ((result.AllowPagging) || (!string.IsNullOrWhiteSpace(defaultSortColumn)))
            {
                if (string.IsNullOrEmpty(options.SortColumn)) options.SortColumn = defaultSortColumn;
                // if (string.IsNullOrEmpty(options.SortColumn)) options.SortColumn = typeof(T).GetProperties()[0].Name;
            }

            if (!string.IsNullOrWhiteSpace(options.SortColumn))
            {
                var pe = Expression.Parameter(typeof(T), "object");
                var expression = Expression.Property(pe, options.SortColumn);
                var valueCast = Expression.Convert(expression, typeof(object));
                var sortExpression = Expression.Lambda<Func<T, object>>(valueCast, pe).Compile();

                query = options.SortDirection == SortDirection.Ascending ? query.OrderBy(sortExpression).AsQueryable() : query.OrderByDescending(sortExpression).AsQueryable();
            }

            result.TotalRows = totalRows ?? 0;
            if (result.AllowPagging)
            {
                result.TotalPages = (int)Math.Ceiling(1.0 * (totalRows ?? query.Count()) / options.PageSize);
                result.CurrentPage = Math.Min(options.CurrentPage ?? 1, result.TotalPages);
                if (!totalRows.HasValue) query =  query.Skip((result.CurrentPage.Value - 1) * options.PageSize).Take(options.PageSize);
            }

            result.List = query.ToList();

            result.SortColumn = options.SortColumn;
            result.SortDirection = options.SortDirection;

            return result;
        }

        public static HtmlString SortColumnLink(this HtmlHelper htmlHelper, GridViewOptions options, string header, string sortBy, string pannelId,
            string pannelUrl, string onSuccess = null)
        {
            return SortColumnLink(htmlHelper, options, header, sortBy, true, pannelId, pannelUrl, onSuccess);
        }

        public static HtmlString SortColumnLink(this HtmlHelper htmlHelper, GridViewOptions options, string header, string sortBy, bool reqByGet = true)
        {
            return htmlHelper.SortColumnLink(options, header, sortBy, reqByGet, null, null, null);
        }

        public static HtmlString SortColumnLink(this HtmlHelper htmlHelper, GridViewOptions options, string header, string sortBy, bool reqByGet, string pannelId, string pannelUrl, string onSuccess)
        {
            if (options == null) options = new GridViewOptions();
            var writer = new HtmlTextWriter(new StringWriter());

            writer.AddAttribute("class",
                string.Compare(sortBy, options.SortColumn, true, CultureInfo.InvariantCulture) == 0
                    ? $"spec-table__sort is-sorted is-{(options.SortDirection == SortDirection.Descending ? "desc" : "asc")}"
                    : "spec-table__sort");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute("class", "spec-table__caption");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            writer.AddAttribute("onclick",
                (pannelId != null) 
                ? $"SortPannelByColumn('{pannelId}', '{sortBy}', '{pannelUrl}' {(string.IsNullOrEmpty(onSuccess) ? "" : ", " + onSuccess)});" // Для панели
                : $"SortByColumn(this, '{sortBy}', {reqByGet.ToString().ToLower()});");
            writer.AddAttribute("class", "sortable clickable");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);

            //if (options != null && string.Compare(sortBy, options.SortColumn, true, CultureInfo.InvariantCulture) == 0)
            //{
            //    var sortTag = new TagBuilder("b");
            //    string direction = "sort-top";
            //    if (options.SortDirection == SortDirection.Descending) direction = "sort-bottom";
            //    sortTag.Attributes.Add("class", direction);

            //    writer.Write(header + sortTag);
            //}
            //else writer.Write(header);
            writer.Write(header);

            writer.RenderEndTag();
            writer.RenderEndTag();
            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }

        public static HtmlString SortColumnLinkMobile(this HtmlHelper htmlHelper, GridViewOptions options, string header, string sortBy, string fixDirection = null, bool reqByGet = true)
        {
            return htmlHelper.SortColumnLinkMobile(options, header, sortBy, fixDirection, reqByGet, null, null, null);
        }

        public static HtmlString SortColumnLinkMobile(this HtmlHelper htmlHelper, GridViewOptions options, string header, string sortBy, string fixDirection, bool reqByGet, string pannelId, string pannelUrl, string onSuccess)
        {
            var func = (pannelId != null)
                ? $"SortPannelByColumn('{pannelId}', '{sortBy}', '{pannelUrl}' {(string.IsNullOrEmpty(onSuccess) ? "" : ", " + onSuccess)});" // Для панели
                : $"SortByColumn(this, '{sortBy}', {reqByGet.ToString().ToLower()}, '{fixDirection}');";

            var link = $"onclick=\"{func}\"";
            return new HtmlString(link);
        }

        public static HtmlString ValuteName (this HtmlHelper htmlHelper, string valuteName)
        {
            var writer = new HtmlTextWriter(new StringWriter());
            writer.Write(", ");
            //writer.AddAttribute("onclick", string.Format(""));
            writer.AddAttribute("class", "valute-name");
            writer.AddAttribute("title", "Нажмите для смены валюты");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.Write(valuteName);
            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }
    }

    //public enum SortDirection
    //{
    //    Ascending = 0,
    //    Descending = 1,
    //}

    public class GridViewModel<T> : GridViewOptions
    {
        public IList<T> List { get; set; }
    }
}