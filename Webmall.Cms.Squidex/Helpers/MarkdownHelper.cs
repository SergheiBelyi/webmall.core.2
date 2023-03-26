using Markdig;
using System.Linq;
using Webmall.Model.Entities.Cms.Localization;

namespace Webmall.Cms.Squidex.Helpers
{
    public static class MarkdownHelper
    {
        public static LString ToHtml(this LString markdown)
        {
            return new LString(markdown.ToDictionary(k => k.Key, v => Markdown.ToHtml(v.Value)));
        }
    }
}
