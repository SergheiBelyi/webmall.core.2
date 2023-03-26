using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Cms.ExternalCatalog;

namespace Webmall.UI.Models
{
    public class ExternalCatalogModel
    {
        public List<CatalogCategory> Catalog { get; set; }
        public string SelectedItemId { get; set; }

        public CatalogCategory SelectedItem
        {
            get { return Catalog.FirstOrDefault(i => i.Slug == SelectedItemId) ?? Catalog.FirstOrDefault() ?? new CatalogCategory(); }
        }
    }
}