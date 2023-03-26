using System;

namespace Webmall.UI.Core.AccessStatistics
{
    public class AccessInfo
    {
        public DateTime AccessTime { get; set; }
        public string URL { get; set; }

        public AccessInfo()
        {
            AccessTime = DateTime.Now;
        }
    }
}