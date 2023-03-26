using System.Collections.Generic;

namespace Webmall.Model.Entities.Cms.ExternalCatalog
{
    public class CatalogCategory
    {
        public CatalogCategory()
        {
            Items = new List<CatalogItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<CatalogItem> Items { get; set; }

    }
}