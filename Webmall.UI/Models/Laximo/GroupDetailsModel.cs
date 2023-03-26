using System;
using System.Collections.Generic;
using Webmall.Laximo.Entities;

namespace Webmall.UI.Models.Laximo
{
    [Serializable]
    public class GroupDetailsModel : BaseModel
    {
        public List<Category> Categories { get; set; }
    }
}