using System.Collections.Generic;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms.Menu
{
    public class MenuLevel1
    {
        public int OrderNumber { get; set; }
        public string Id { get; set; }
        public LString Title { get; set; }
        public LString Url { get; set; }
        public bool ForGrossOnly { get; set; }
        public bool ForRetailOnly { get; set; }
        public List<MenuLevel2> Level2 { get; set; } = new List<MenuLevel2>();
    }
}