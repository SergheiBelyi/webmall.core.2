using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using ValmiStore.Model;
using ValmiStore.Model.Entities;
using Webmall.Model;

namespace Webmall.UI.Core
{
    public static class TreeMenuRenderer
    {
       //#region Logger

       // private static readonly ILog Log = LogManager.GetLogger(typeof(TreeMenuRenderer));

       // static TreeMenuRenderer()
       // {
       //     XmlConfigurator.Configure();
       // }

       // #endregion

        public static string RenderModifTree(this HtmlHelper htmlHelper, List<Group> rootLocations, Group selectedGroup, string rootName, Func<Group, string> urlMaker, bool async = false)
        {
            var tree = new LeftMenuRenderer(rootLocations, rootName, selectedGroup, null,
                (liAttributes, level, location) =>
                {
                    string css = string.Empty;
                    var open = location.ContainsDeep(selectedGroup) || location == selectedGroup || (selectedGroup == null && location.Id == "10001");
                    //
                    if (open || (level == 1 && rootLocations.Last().Equals(location))) css += "open is-active ";
                    if (location == selectedGroup || (selectedGroup != null && location.Id == selectedGroup.Id)) css += "current ";
                    if (location.Children.Any() && level != 1) css += "hasChildren ";
                    liAttributes.Add(HtmlTextWriterAttribute.Class, css);
                }, null).Render(urlMaker, async);
            return tree;
        }

    }

    public class LeftMenuRenderer
    {
       //#region Logger

       // private static readonly ILog LogI = LogManager.GetLogger(typeof(LeftMenuRenderer));
       // public static ILog Log { get { return LogI; } }
       // public static void InitializeLogger() { XmlConfigurator.Configure(); }

       // static LeftMenuRenderer()
       // {
       //     InitializeLogger();
       // }

       // #endregion
        private readonly List<Group> _rootLocations;
        private HtmlTextWriter _writer;
        private readonly string _rootClassName;
        private readonly Group _selectedGroup;
        readonly Action<Dictionary<HtmlTextWriterAttribute, string>, int> _ulAction;
        readonly Action<Dictionary<HtmlTextWriterAttribute, string>, int, Group> _liAction;
        readonly Action<HtmlTextWriter, int, Group> _liPostAction;

        public LeftMenuRenderer(List<Group> rootLocations, string rootClassName, Group selectedGroup,
            Action<Dictionary<HtmlTextWriterAttribute, string>, int> ulAction,
            Action<Dictionary<HtmlTextWriterAttribute, string>, int, Group> liAction,
            Action<HtmlTextWriter, int, Group> liPostAction)
        {
            _rootLocations = rootLocations;
            _rootClassName = rootClassName;
            _selectedGroup = selectedGroup;
            _liAction = liAction;
            _ulAction = ulAction;
            _liPostAction = liPostAction;
        }

        public string Render(Func<Group, string> urlMaker, bool async)
        {
            _writer = new HtmlTextWriter(new StringWriter());
            RenderLocations(1, _rootLocations, urlMaker, async);
            return _writer.InnerWriter.ToString();
        }

        private void RenderLocations(int level, List<Group> locations, Func<Group, string> urlMaker, bool async)
        {
            //Log.DebugFormat("Locations for render level {1}: {0}", locations == null ? null : locations.Count().ToString(), level);

            if (locations == null || !locations.Any()) return;

            var ulAttributes = new Dictionary<HtmlTextWriterAttribute, string> {{HtmlTextWriterAttribute.Abbr, string.Format("level {0}", level)}};
            if (_ulAction != null) _ulAction(ulAttributes, level);
            if (level == 1)
            {
                ulAttributes.Add(HtmlTextWriterAttribute.Id, _rootClassName);
                //ulAttributes.Add(HtmlTextWriterAttribute.Style,
                //                 async ? "overflow:hidden;" : "display:none; overflow:hidden;");
            }
            InUl(() =>
                     {
                         bool isSelected = (_selectedGroup != null &&
                                            Helper.GetItemInTreeById(locations, _selectedGroup.Id) != null);
                         if (!async || level == 1 || level == 2 || isSelected)
                         {
                             foreach (var loc in locations)
                             {
                                 //string url = null;
                                 //if (urlMaker != null)
                                 //    url = urlMaker(location);
                                 //if (!(isSelected || url == null)) continue;
                                 var location = loc;
                                 var liAttributes = new Dictionary<HtmlTextWriterAttribute, string>
                                 {
                                     {HtmlTextWriterAttribute.Id, location.Id},
                                     {HtmlTextWriterAttribute.Title, location.Name},
                                 };
                                 if (_liAction != null) _liAction(liAttributes, level, location);
                                 //
                                 InLi(() =>
                                          {
                                              string url = null;
                                              if (urlMaker != null)
                                                  url = urlMaker(location);
                                              //InSpan(() => _writer.Write(url ?? location.Name), null);
                                              //_writer.Write(url ?? location.Name);

                                              if (location.SubGroup.Count > 0)
                                              {
                                                  //InSpan(() => _writer.Write(url ?? location.Name), null);
                                                  InTag(HtmlTextWriterTag.A, () => _writer.Write(url ?? location.Name), new Dictionary<HtmlTextWriterAttribute, string> { { HtmlTextWriterAttribute.Href, "#" } });
                                                  RenderLocations(level + 1, location.SubGroup, urlMaker, async);
                                              }
                                              else
                                              {
                                                  _writer.Write(url ?? location.Name);
                                              }
                                          }, liAttributes);
                                 //
                                 if (locations.Last().Equals(location)) continue;
                                 //
                                 if (_liPostAction != null) _liPostAction(_writer, level, location);
                             }
                         }
                         else //if (async)
                         {
                             var liAttributes = new Dictionary<HtmlTextWriterAttribute, string>();
                             InLi(() =>
                                      {
                                          var spanAtrr = new Dictionary<HtmlTextWriterAttribute, string> {{HtmlTextWriterAttribute.Class, "placeholder"}};
                                          InSpan(() => _writer.Write("&nbsp;"), spanAtrr);
                                      }, liAttributes);
                         }
                     }, ulAttributes);
        }

        public void InUl(Action action, Dictionary<HtmlTextWriterAttribute, string> attributes)
        {
//            Log.DebugFormat("InUl: attributes {0}", attributes.Count);
            _writer.Write(_writer.NewLine);
            if (attributes.Count > 0)
            {
                foreach (var attr in attributes)
                    _writer.AddAttribute(attr.Key, attr.Value);
            }
            _writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            action();
            _writer.RenderEndTag();
        }

        public static void InLi(HtmlTextWriter writer, Action action, Dictionary<HtmlTextWriterAttribute, string> attributes)
        {
//            Log.DebugFormat("InLi: attributes {0}", attributes.Count);
            writer.Write(writer.NewLine);
            if (attributes.Count > 0)
            {
                foreach (var attr in attributes)
                    writer.AddAttribute(attr.Key, attr.Value);
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            action();
            writer.RenderEndTag();
        }

        public void InLi(Action action, Dictionary<HtmlTextWriterAttribute, string> attributes)
        {
            InLi(_writer, action, attributes);
        }

        private void InSpan(Action action, Dictionary<HtmlTextWriterAttribute, string> attributes)
        {
//            Log.DebugFormat("InSpan: attributes {0}", attributes.Count);
            _writer.Write(_writer.NewLine);
            if (attributes != null && attributes.Count > 0)
            {
                foreach (var attr in attributes)
                    _writer.AddAttribute(attr.Key, attr.Value);
            }
            _writer.RenderBeginTag(HtmlTextWriterTag.Span);
            action();
            _writer.RenderEndTag();
        }

        private void InTag(HtmlTextWriterTag tag, Action action, Dictionary<HtmlTextWriterAttribute, string> attributes)
        {
            //            Log.DebugFormat("InSpan: attributes {0}", attributes.Count);
            _writer.Write(_writer.NewLine);
            if (attributes != null && attributes.Count > 0)
            {
                foreach (var attr in attributes)
                    _writer.AddAttribute(attr.Key, attr.Value);
            }
            _writer.RenderBeginTag(tag);
            action();
            _writer.RenderEndTag();
        }
    }
}
