using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Webmall.Model;

namespace Webmall.UI.Core
{
    public class GridViewOptions
    {
        public bool AllowPagging { get; set; }

        public bool AllowPageSizeSelection { get; set; }

        public ControllerContext Context { get; set; }
        public string SortColumn { get; set; }

        
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
        public int? CurrentPage { get; set; }
        public string BrandFilter { get; set; }

        private string _currentContent = "";

        public int Skip => PageSize * ((CurrentPage ?? 1) - 1);

        public string CurrentContent {
            get => _currentContent;
            set
            {
                _currentContent = value;
                var cookie = HttpContext.Current.Request.Cookies[SortTypeCookieName];
                if (cookie != null) SortColumn = cookie.Value;

                cookie = HttpContext.Current.Request.Cookies[SortDirCookieName];
                if (cookie != null) SortDirection = (SortDirection)Enum.Parse(SortDirection.GetType(), cookie.Value); 
            }
        }

        
        private const string PageSizeCookieKey = "_Webmall_PageSize";
        public string SortTypeCookieName => _currentContent + "_SORT_TYPE";
        public string SortDirCookieName => _currentContent + "_SORT_DIR";

        //public const string CatalogContent = "WEBMALL_CATALOG";

        private int? _pageSize;
        public int PageSize 
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    var size = 12;
                    if (AllowPageSizeSelection)
                    {
                        var cookie = HttpContext.Current.Request.Cookies[_currentContent+PageSizeCookieKey];
                        if (cookie != null) int.TryParse(cookie.Value, out size);
                    }
                    _pageSize = size;
                }
                return _pageSize.Value;
            }
            set
            {
                _pageSize = value;
                if (AllowPageSizeSelection)
                {
                    var cookie = new HttpCookie(PageSizeCookieKey, _pageSize.ToString()) {Expires = DateTime.MaxValue};
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }

        public GridViewOptions()
        {
            AllowPageSizeSelection = ConfigHelper.AllowPageSizeSelection;
            AllowPagging = true;
        }
    }
}