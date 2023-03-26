using System.Linq;
using System.Text;
using StackExchange.Profiling;
using Webmall.Model;

namespace Webmall.UI.Core.MiniProfiler
{
    public static class MiniProfilerHelper
    {
        public static string RenderPlainText(this Timing t, int level = 0)
        {
            var result = new StringBuilder();
            var s = new string ('\t', level);
            result.AppendFormat(s+"{0} = {1:n2} ms, start: {2} ms, pTstart: {3}", t.Name, t.DurationMilliseconds, t.StartMilliseconds, t.ParentTiming?.StartMilliseconds ?? 0);
            if (t.CustomTimings != null)
            {
                result.Append(" (");
                foreach (var cT in t.CustomTimings)
                {
                    result.Append(string.Format("{0} = {1:n2} ms in {2} cmd,", cT.Key, cT.Value.Sum(i => i.DurationMilliseconds), cT.Value.Count));
                }
                result.AppendLine(")");
                result.AppendLine("------------------------");
                foreach (var cT in t.CustomTimings)
                {
                    foreach (var cTv in cT.Value)
                    {
                        result.AppendLine(s + string.Format("{0} ({1}): {2:n2} ms, start: {3} ms, cmd {5}, stack {4}",
                            cT.Key, cTv.ExecuteType, cTv.DurationMilliseconds, cTv.StartMilliseconds, cTv.StackTraceSnippet, cTv.CommandString));
                    }
                }
                result.AppendLine("------------------------");
            }
            else result.AppendLine("");

            if (t.Children != null)
                foreach (var timing in t.Children.Where(i=>ConfigHelper.ProfilerShowTrivial || i.DurationMilliseconds > StackExchange.Profiling.MiniProfiler.Current.Options.TrivialDurationThresholdMilliseconds))
                    result.AppendLine(RenderPlainText(timing, level + 1));

            return result.ToString();
        }

        public static string RenderPlainTextEx(this StackExchange.Profiling.MiniProfiler profiler)
        {
            return (profiler.Root != null && profiler.Root.DurationMilliseconds > ConfigHelper.ProfilerLogTimeLimit*1000) ? profiler.Root.RenderPlainText() : null;
        }
    }
}