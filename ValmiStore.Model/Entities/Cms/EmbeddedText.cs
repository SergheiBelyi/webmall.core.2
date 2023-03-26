using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Model.Entities.Cms
{
    public class EmbeddedText
    {
        public int Id { get; set; }
        public LString Name { get; set; }
        public LString Description { get; set; }
    }
}
