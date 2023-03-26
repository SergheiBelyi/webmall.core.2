using System;

namespace Webmall.Model.Entities.Cms.Brand
{
    public class BrandNewsItem
    {
        public string Title { get; set; }
        public string Date { get; set; }

        public DateTime DateAsDate => DateTime.Parse(Date);
    }
}
