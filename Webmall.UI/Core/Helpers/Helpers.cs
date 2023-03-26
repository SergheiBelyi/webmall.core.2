using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using log4net;
using log4net.Config;
using ValmiStore.Model.Entities;
using ViewRes;

namespace Webmall.UI.Core.Helpers
{
    public static class CommonHelpers
    {
        #region Logger

        public static readonly ILog Log = LogManager.GetLogger(typeof(CommonHelpers));

        static CommonHelpers()
        {
            XmlConfigurator.Configure();
        }

        #endregion

        public static readonly string PropertyDivider = "-";
        public static readonly string PrivateCookieName = "WebMallPrivate";
        public static Assembly AppAssembly;
        // ReSharper disable once InconsistentNaming
        public const string LASTAUTO_COOKIENAME = "WebmallLastAuto";

        //public static string GetIconUrlByType(string fileName)
        //{
        //    if (string.IsNullOrWhiteSpace(fileName)) return string.Empty;
        //    //
        //    var fi = new System.IO.FileInfo(fileName);
        //    //   var extention = fileName.Substring(fileName.Length - 4);
        //    switch (fi.Extension.ToLower())
        //    {
        //        case ".zip":
        //        case ".rar":
        //            return "zip";
        //        case ".txt":
        //            return "txt";
        //        case ".pdf":
        //            return "pdf";
        //        case ".rtf":
        //        case ".doc":
        //        case ".docx":
        //            return "doc";
        //        case ".xls":
        //        case ".xlsx":
        //            return "xls";
        //        default:
        //            return "blank";
        //    }
        //}

        //public static string GetIconByType(string fileName)
        //{
        //    if (string.IsNullOrWhiteSpace(fileName)) return string.Empty;
        //    //
        //    var fi = new System.IO.FileInfo(fileName);
        //    //   var extention = fileName.Substring(fileName.Length - 4);
        //    switch (fi.Extension.ToLower())
        //    {
        //        case ".zip":
        //        case ".rar":
        //            return "file-zip";
        //        case ".txt":
        //            return "file-txt";
        //        case ".pdf":
        //            return "file-pdf";
        //        case ".rtf":
        //        case ".doc":
        //        case ".docx":
        //            return "file-doc";
        //        case ".xls":
        //        case ".xlsx":
        //            return "file-xls";
        //        default:
        //            return "blank";
        //    }
        //}


        //// ReSharper disable once InconsistentNaming
        //public static string MD5(string input)
        //{
        //    var md5 = new MD5CryptoServiceProvider();

        //    var data = md5.ComputeHash(Encoding.Default.GetBytes(input));

        //    var sBuilder = new StringBuilder();

        //    for (var i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }

        //    return sBuilder.ToString();
        //}

        //// ReSharper disable once InconsistentNaming
        //public static string SHA1(string input, bool raw = false)
        //{
        //    SHA1 hash = System.Security.Cryptography.SHA1.Create();
        //    var encoder = new ASCIIEncoding();
        //    byte[] combined = encoder.GetBytes(input);
        //    hash.ComputeHash(combined);
        //    return Convert.ToBase64String(hash.Hash);
        //}


        //public static string EncodeToBase64(string toEncode)
        //{
        //    byte[] toEncodeAsBytes
        //          = Encoding.ASCII.GetBytes(toEncode);
        //    string returnValue
        //          = Convert.ToBase64String(toEncodeAsBytes);
        //    return returnValue;
        //}

        //public static string DecodeBase64(string toDecode)
        //{
        //    var returnValueAsBytes
        //          = Convert.FromBase64String(toDecode);
        //    string returnValue = Encoding.ASCII.GetString(returnValueAsBytes);

        //    return returnValue;
        //}

        //public static string SelectSingleNodeValue(this XmlNode node, string name)
        //{
        //    var selectSingleNode = node.SelectSingleNode(name);
        //    return selectSingleNode?.FirstChild != null ? selectSingleNode.FirstChild.Value : "";
        //}

        private static DateTime? _buildTime;
        private static Version _version;

        public static string VersionInfo()
        {
            if (_version == null)
                _version = (AppAssembly ?? Assembly.GetExecutingAssembly()).GetName().Version;
            return SharedResources.Version + $": {_version.Major}.{_version.Minor}.{_version.Build}";
        }

        public static string BuildTime()
        {
            if (!_buildTime.HasValue)
                _buildTime = File.GetLastWriteTime((AppAssembly ?? Assembly.GetExecutingAssembly()).Location);
            return _buildTime.ToString();
        }

        public static void AutoSelectionToCookie(string autoMark, string autoModel, string modif)
        {
            //var cookie = new HttpCookie(LASTAUTO_COOKIENAME, String.Format("{0}|{1}|{2}", autoMark, autoModel, modif)) {Expires = DateTime.MaxValue};
            CookieHelper.SetCookie(LASTAUTO_COOKIENAME, $"{autoMark}|{autoModel}|{modif}");
        }

        public static void AddExceptionToMail(MailMessage mail, Exception ex)
        {
            mail.Body += "<br/>" + "Exception";
            mail.Body += "<br/>" + ex.Message;
            if (ex.StackTrace != null)
            {
                mail.Body += "<br/>" + ex.StackTrace.Trim();
            }
            while (ex.InnerException != null)
            {
                mail.Body += "<br/>" + "Inner exception";
                ex = ex.InnerException;
                mail.Body += "<br/>" + ex.Message;
                if (ex.StackTrace != null)
                {
                    mail.Body += "<br/>" + ex.StackTrace.Trim();
                }
            }
        }

        public static string PriceTitle(Offer el)
        {
            if (el == null || !el.BasePrice.HasValue)
                return SharedResources.NoData;
            var result = $"{SharedResources.Price}: {SessionHelper.PriceFormat(el.BasePrice / SessionHelper.CurrentValute.Rate)}";
            if (el.DiscountPercentage != 0)
                result += $", {SharedResources.Discount}: {el.DiscountPercentage}%";
            return result;
        }

        public static List<KeyValuePair<string, string>> GetFilter(System.Collections.Specialized.NameValueCollection allParems)
        {
            var filter = new List<KeyValuePair<string, string>>();
            foreach (var key in allParems.AllKeys)
            {
                if (key.StartsWith("_filter_"))
                    filter.Add(new KeyValuePair<string, string>(key.Replace("_filter_", ""), allParems[key]));
            }

            return filter;
        }

        public static bool ValidateVin(this string vin)
        {
            if (vin?.Length >= 6 && vin.Length <= 14)
                return true;
            return !(string.IsNullOrEmpty(vin) || vin.Length != 17
                || !vin.All(i => (i >= 'A' && i <= 'Z' || i >= '0' && i <= '9') && i != 'O')
                || !vin.Substring(12).All(i => i >= '0' && i <= '9'));
        }

        //public static bool ValidateVin(this string vin)
        //{
        //    if (vin.Length != 17)
        //        return false;
        //    var result = 0;
        //    var index = 0;
        //    var checkDigit = 0;
        //    var checkSum = 0;
        //    var weight = 0;
        //    foreach (var c in vin.ToCharArray())
        //    {
        //        index++;
        //        var character = c.ToString().ToLower();
        //        if (char.IsNumber(c))
        //            result = int.Parse(character);
        //        else
        //        {
        //            switch (character)
        //            {
        //                case "a":
        //                case "j":
        //                    result = 1;
        //                    break;
        //                case "b":
        //                case "k":
        //                case "s":
        //                    result = 2;
        //                    break;
        //                case "c":
        //                case "l":
        //                case "t":
        //                    result = 3;
        //                    break;
        //                case "d":
        //                case "m":
        //                case "u":
        //                    result = 4;
        //                    break;
        //                case "e":
        //                case "n":
        //                case "v":
        //                    result = 5;
        //                    break;
        //                case "f":
        //                case "w":
        //                    result = 6;
        //                    break;
        //                case "g":
        //                case "p":
        //                case "x":
        //                    result = 7;
        //                    break;
        //                case "h":
        //                case "y":
        //                    result = 8;
        //                    break;
        //                case "r":
        //                case "z":
        //                    result = 9;
        //                    break;
        //            }
        //        }

        //        if (index >= 1 && index <= 7 || index == 9)
        //            weight = 9 - index;
        //        else if (index == 8)
        //            weight = 10;
        //        else if (index >= 10 && index <= 17)
        //            weight = 19 - index;
        //        if (index == 9)
        //            checkDigit = character == "x" ? 10 : result;
        //        checkSum += (result * weight);
        //    }

        //    return checkSum % 11 == checkDigit;
        //}
    }
}