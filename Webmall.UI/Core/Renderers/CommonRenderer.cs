using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Webmall.Model.Abstract;

namespace Webmall.UI.Core.Renderers
{
    public static class CommonRenderer
    {
        public static string RenderTree<T>(this HtmlHelper htmlHelper, List<ICommonTreeComposite<T>> rootLocations, ICommonTreeComposite<T> selectedItem, string rootName, Func<ICommonTreeComposite<T>, string> urlMaker, bool async = false) where T : class
        {
            var tree = new TreeRenderer<T>(rootLocations, rootName, selectedItem, null,
                (liAttributes, level, location) =>
                {
                    string css = string.Empty;
                    var open = ContainsDeep(location, selectedItem) || location == selectedItem;

                    if (open || (level == 1 && rootLocations.Last().Equals(location))) css += "is-opened is-active ";
                    if (location == selectedItem || (selectedItem != null && location.Id == selectedItem.Id)) css += "current ";
                    if (location.Children.Any() && level != 1) css += "hasChildren ";
                    liAttributes.Add(HtmlTextWriterAttribute.Class, css);
                }, null).Render(urlMaker, async);
            return tree;
        }

        public static bool ContainsDeep<T>(ICommonTreeComposite<T> rootItem, ICommonTreeComposite<T> item) where T : class
        {
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
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                // ReSharper disable once AssignmentInConditionalExpression
                if (result = ContainsDeep(child, item)) break;
            }
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return result;
        }

        public static ICommonTreeComposite<T> GetItemInTreeById<T>(IEnumerable<ICommonTreeComposite<T>> items, string id)
        {
            var result = default(ICommonTreeComposite<T>);

            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    result = item;
                    break;
                }

                result = GetItemInTreeById(item.Children, id);

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

    }
}