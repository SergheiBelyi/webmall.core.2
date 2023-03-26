using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using log4net;
using log4net.Config;
using Webmall.Model;

namespace Webmall.UI.Core.AccessStatistics
{
    /// <summary>
    /// Статистика обращений
    /// </summary>
    public class AccessStatistic : Dictionary<string, AccessInfoList>
    {
        /// <summary>
        /// Процесс публикации статистики
        /// </summary>
        private static Thread ProcessingThread { get; set; }

        private const string Separator = ";";

        private DateTime _nextTrunc = DateTime.Now + TruncPeriod;
        public static TimeSpan TruncPeriod = new TimeSpan(12, 0, 0);

        public static AccessStatistic Instance;

        private static readonly List<string> IgnoreList = new List<string> { ".css", ".png", ".gif", ".jpg", ".js", "ShowImage.ashx", "GetBrandImage", "Images/GetImage", "/bundles", "/Content", "/api" };

        #region Logger

        // ReSharper disable InconsistentNaming
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccessStatistic));
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// инициализация логера
        /// </summary>
        public static void InitializeLogger()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        static AccessStatistic()
        {
            InitializeLogger();
        }

        public static string GenerateKey()
        {
            var identityName = (HttpContext.Current.User != null) ? HttpContext.Current.User.Identity.Name : "";
            return HttpContext.Current.Request.UserHostAddress + ',' + identityName + ',' +
                   HttpContext.Current.Request.Browser.Browser;
        }

        private static bool IgnoreUrl(string url)
        {
            return IgnoreList.Any(i => url.Contains(i));
        }

        public bool IsCurrentUserBlocked
        {
            get
            {
                try
                {
                    var accessKey = GenerateKey();
                    if (ContainsKey(accessKey))
                    {
                        var accessInfo = this[accessKey];
                        if (accessInfo.IsBlocked && !accessInfo.IsHuman) return true;
                    }

                }
                catch (Exception)
                {
                }
                return false;
            }
            set
            {
                var accessKey = GenerateKey();
                if (ContainsKey(accessKey))
                {
                    var accessInfo = this[accessKey];
                    accessInfo.IsBlocked = value;
                }
            }
        }

        public void ClearCurrentUSerBlock()
        {
            var accessKey = GenerateKey();
            if (ContainsKey(accessKey))
            {
                var accessInfo = this[accessKey];
                accessInfo.IsBlocked = false;
                accessInfo.IsHuman = true;
                //accessInfo.Clear();
            }

        }

        public void AddRecord(HttpRequest request)
        {
            if (IgnoreUrl(request.Url.OriginalString) || request.AppRelativeCurrentExecutionFilePath == "~/")
                return;
            StartPublishing();
            var accessKey = GenerateKey();
            if (accessKey != null)
            {
                try
                {
                    AccessInfoList accessInfo;
                    if (ContainsKey(accessKey))
                    {
                        accessInfo = this[accessKey];
                        Trunc();
                    }
                    else
                    {
                        accessInfo = new AccessInfoList();
                        try
                        {
                            Add(accessKey, accessInfo);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    try
                    {
                        accessInfo.Add(new AccessInfo { URL = request.Url.OriginalString });
                    }
                    catch (Exception)
                    {
                        accessInfo = new AccessInfoList();
                    }
                    accessInfo.CheckForBlock();
                    if ((accessInfo.Count > 300 || accessInfo.IsBlocked) && !accessInfo.WasNotified)
                    {
                        accessInfo.WasNotified = true;
                        var address = ConfigHelper.AccessManagerEmail;
                        if (address != null)
                        {
                            var message = new MailMessage
                            {
                                Subject = "Access Statistics Warning",
                                Body = "<table><tr><td>" + MessageHeader("</td><td>") + "</td></tr><tr><td>" + MessageLine("</td><td>", accessInfo) + "</td></tr></table>",
                            };

                            MailHelper.SendMailMessage(address, message);
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        private void Trunc()
        {
            if (DateTime.Now > _nextTrunc)
            {
                try
                {
                    foreach (var item in this.ToList())
                    {
                        item.Value.Trunc();
                        if (item.Value.Count == 0)
                        {
                            Remove(item.Key);
                        }
                    }

                }
                catch (Exception)
                {
                }
                _nextTrunc += TruncPeriod;
            }
        }

        public static void StartPublishing()
        {
            if (ProcessingThread == null)
            {
                ProcessingThread = new Thread(Process);
                ProcessingThread.Start();
            }
        }

        private static void Process()
        {
            try
            {
                Log.Debug("Access statistic publishing process started");
                while (ProcessingThread.IsAlive)
                {
                    Log.Debug("Processing cycle started");

                    const double sleep = 6.0;// 1 / 2.0;

                    Thread.Sleep(TimeSpan.FromHours(sleep));
                    Instance.WriteToFile();
                    string address = ConfigHelper.AccessManagerEmail;
                    if (address != null)
                    {
                        try
                        {
                            using (var tw = new StreamWriter(new MemoryStream()))
                            {
                                Instance.WriteToStream(tw);
                                tw.Flush();
                                tw.BaseStream.Position = 0;
                                //string body;
                                //using (var reader = new StreamReader(tw.BaseStream, Encoding.UTF8))
                                //    body = reader.ReadToEnd();
                                var message = new MailMessage { Subject = "Access Statistics Reports", Body = DateTime.Now.ToShortDateString(), };
                                message.Attachments.Add(new Attachment(tw.BaseStream,
                                    $"log{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString().Replace(':', '.')}.csv"));
                                MailHelper.SendMailMessage(address, message);

                                tw.Close();
                            }
                        }
                        catch (Exception exc)
                        {
                            Log.FatalFormat("Access statistic publishing process error: {0}. Trace: {1}", exc.Message, exc);
                        }
                    }
                }
                Log.Debug("Access statistic publishing process stoped");

            }
            catch (ThreadAbortException)
            {
                Log.Debug("Access statistic publishing process aborted");
            }
            catch (Exception exc)
            {
                Log.FatalFormat("Access statistic publishing process error: {0}. Trace: {1}", exc.Message, exc);
            }

        }

        void WriteToStream(StreamWriter stream)
        {
            stream.WriteLine(MessageHeader(Separator));
            foreach (var item in Values.ToArray())
            {
                stream.WriteLine(MessageLine(Separator, item));
            }
        }

        private static string MessageLine(string s, AccessInfoList item)
        {

            return string.Format("{0}" + s + "{1}" + s + "{2}" + s + "{3}" + s + "{4}" + s + "{5:n2}" + s + "{6:n2}" + s + "{7:n2}" + s +
            "{8:n2}" + s + "{9:n2}" + s + "{10:n2}" + s + "{11:n2}" + s + "{12:n2}",
            item.IP, item.User, item.Browser, item.Duration.ToString("hh\\:mm\\:ss"), item.Count,
            item.RequestsPerSecondMin, item.RequestsPerSecond, item.RequestsPerSecondNorm, item.RequestsPerSecondMax,
            item.RequestsPerMinuteMin, item.RequestsPerMinute, item.RequestsPerMinuteNorm, item.RequestsPerMinuteMax);
        }

        private static string MessageHeader(string s)
        {
            return "IP" + s + "User" + s + "Browser" + s + "Duration" + s + "Count" + s + "RpsMin" + s + "RpsAv" + s + "RpsAvN" + s + "RpsMax" + s + "RpmMin" + s + "RpmAv" + s + "RpmAvN" + s + "RpmMax";
        }

        public string WriteToFile()
        {
            //int iisNumber = 2;
            //VirtualDirectory virtualRoot = null;
            //using (var serverManager = new ServerManager())
            //{
            //    var site = serverManager.Sites.Single(s => s.Id == iisNumber);
            //    var applicationRoot =
            //             site.Applications.Single(a => a.Path == "/");
            //    virtualRoot =
            //             applicationRoot.VirtualDirectories.Single(v => v.Path == "/");
            //    //Console.WriteLine(virtualRoot.PhysicalPath);
            //}
            //            var p = HostingEnvironment.MapPath("");
            // create a writer and open the file
            var path = ConfigHelper.AccessLogPath;
            var fileName = $"{path}log_{DateTime.Now.ToShortDateString()}_{ DateTime.Now.ToShortTimeString().Replace(':', '.')}.csv";
            using (var tw = new StreamWriter(fileName))
            {
                WriteToStream(tw);
                tw.Close();
            }
            return fileName;
        }
    }
}