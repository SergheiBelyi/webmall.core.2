using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.Footer
{
    public class FooterColumn
    {
        public int OrderNumber { get; set; }
        public string Id { get; set; }
        public LString Title { get; set; }
        public List<FooterPosition> Positions { get; set; } = new List<FooterPosition>();
    }
}