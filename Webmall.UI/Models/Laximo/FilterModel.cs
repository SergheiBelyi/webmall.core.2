using System;
using System.Collections.Generic;
using Webmall.Laximo.Entities;

namespace Webmall.UI.Models.Laximo
{
    [Serializable]
    public class FilterModel : BaseModel
    {
        public List<Filter> Filters { get; set; }
    }
}