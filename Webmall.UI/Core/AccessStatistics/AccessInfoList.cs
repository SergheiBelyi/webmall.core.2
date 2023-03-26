using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;
using Webmall.Model;

namespace Webmall.UI.Core.AccessStatistics
{
    public class AccessInfoList : List<AccessInfo>
    {
        #region Logger

        private static readonly ILog LogI = LogManager.GetLogger(typeof(AccessInfoList));
        public static ILog Log { get { return LogI; } }
        private static void InitializeLogger() { XmlConfigurator.Configure(); }

        static AccessInfoList()
        {
            InitializeLogger();
        }

        #endregion


       // public static TimeSpan TruncPeriod = new TimeSpan(12, 0, 0);
        public string Key { get; set; }
// ReSharper disable once InconsistentNaming
        public string IP { get; set; }
        public string Browser { get; set; }
        public string User { get; set; }

        public bool IsBlocked { get; set; }
        public bool IsHuman { get; set; }

        public bool WasNotified { get; set; }

        public AccessInfoList()
            : this(HttpContext.Current)
        {
            Key = AccessStatistic.GenerateKey();
            IsBlocked = false;
            IsBlocked = false;
        }

        public AccessInfoList(HttpContext context)
        {
            IP = context.Request.UserHostAddress;
            Browser = context.Request.Browser.Browser;
            User = context.User.Identity.Name;
        }

        public TimeSpan Duration {
            get
            {
                return this.Last().AccessTime - this.First().AccessTime;
            }
        }

        public double RequestsPerSecond
        {
            get { return RequestsPer(TimeParts.Seconds); }
        }

        public double RequestsPerSecondMin
        {
            get { return NormalizedMinRequestsPer(TimeParts.Seconds); }
        }

        public double RequestsPerSecondMax
        {
            get { return NormalizedMaxRequestsPer(TimeParts.Seconds); }
        }

        public double RequestsPerSecondNorm
        {
            get { return NormalizedAverageRequestsPer(TimeParts.Seconds); }
        }

        public double RequestsPerMinuteMin
        {
            get { return NormalizedMinRequestsPer(TimeParts.Minutes); }
        }

        public double RequestsPerMinuteMax
        {
            get { return NormalizedMaxRequestsPer(TimeParts.Minutes); }
        }

        public double RequestsPerMinute
        {
            get { return RequestsPer(TimeParts.Minutes); }
        }

        public double RequestsPerMinuteNorm
        {
            get { return NormalizedAverageRequestsPer(TimeParts.Minutes); }
        }

        public double RequestsPer(TimeParts precision)
        {
            //var result = this.AsQueryable()
            //    .GroupBy(i => RoundTime(i.AccessTime))
            //    .Select(i => new {i.Key, count = i.Count()})
            //    .Average(i => i.count);

            var duration = Duration;
            var result = ((double)Count) / ((int) (((precision == TimeParts.Seconds) ? duration.TotalSeconds : (precision == TimeParts.Minutes) ?  duration.TotalMinutes : duration.TotalHours)) + 1); 
            return result;
        }

        public double NormalizedAverageRequestsPer(TimeParts precision)
        {
            double result = 0;
            try
            {
                result = NormalizedRequestSelect(precision).Average(i => i.Cnt);
            }
            catch
            {
            }
            return result;
        }

        public int NormalizedMaxRequestsPer(TimeParts precision)
        {
            var result = 0;
            try
            {
                result = NormalizedRequestSelect(precision).Max(i => i.Cnt);
            }
            catch (Exception)
            {
            }
            return result;
        }

        public int NormalizedMinRequestsPer(TimeParts precision)
        {
            var result = 0;
            try {
            result = NormalizedRequestSelect(precision).Min(i => i.Cnt);
            }
            catch (Exception)
            {
            }
            return result;
        }

        private IQueryable<NormalizedData> NormalizedRequestSelect(TimeParts precision)
        {
            var result = this.AsQueryable()
                       .GroupBy(i => RoundTime(i.AccessTime, precision).ToString())
                       .Select(i => new NormalizedData { Key = i.Key, Cnt = i.Count() });
            //var tmp = this.AsQueryable()
            //              .GroupBy(i => RoundTime(i.AccessTime, precision)).ToArray();
            return result;
        }

        public void Trunc()
        {
            try
            {
                var limit = DateTime.Now - AccessStatistic.TruncPeriod;
                var listToRemove = this.Where(item => item.AccessTime < limit).ToArray();
                for (int i = 0; i < listToRemove.Length; i++)
                {
                    Remove(listToRemove[i]);
                }
            }
            catch (Exception e)
            {
                Log.Debug("Trunc error: ", e);
            }
        }

        private static DateTime RoundTime(DateTime time, TimeParts precision)
        {
            var result = time.AddMilliseconds(-time.Millisecond);
            if (precision == TimeParts.Minutes)
                result = result.AddSeconds(-result.Second);
            if (precision == TimeParts.Hours)
                result = result.AddMinutes(-result.Minute);
            return result;
        }

        private class NormalizedData
        {
// ReSharper disable once NotAccessedField.Local
            public string Key;
            public int Cnt;
        }

        public enum TimeParts
        {
            Seconds, Minutes, Hours
        }

        internal void CheckForBlock()
        {
            if (!IsBlocked)
            {
                IsBlocked = (RequestsPerMinuteNorm > ConfigHelper.RequestsPerMinuteLimit 
                    //&& RequestsPerSecondNorm > 10 
                    && Count > 50);
            }
        }
    }
}