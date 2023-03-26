using System.Collections.Generic;
using System.Linq;

namespace Webmall.Cms.Squidex.Core.Model
{
    public class LTag : Dictionary<string, string[]>
    {
        public Dictionary<string, string> LTagStrings => this.ToDictionary(k => k.Key, v => string.Join(",", v.Value));
    }
}
