
using System.Web.UI.WebControls;

namespace Webmall.Model.Entities
{
    public class PageOptions
    {
        public string OrderColumn { get; set; }
        public string OrderDirection => Direction == SortDirection.Ascending ? "ASC" : "DESC";
        public SortDirection Direction { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
