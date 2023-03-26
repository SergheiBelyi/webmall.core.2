using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ViewRes;
using Webmall.Model.Abstract;
using Webmall.Model.Entities.User;

namespace Webmall.Model
{
    public static class Helper
    {
        private const int MaxVisibleQnt = 10;

        /// <summary>
        /// Формирует строку из списка значений с заданным разделитетем
        /// </summary>
        /// <typeparam name="T">Тип элементов списка</typeparam>
        /// <param name="list">Список</param>
        /// <param name="delimiter">Разделитель</param>
        /// <returns>Результирующая строка</returns>
        public static string ListToString<T>(IList<T> list, string delimiter)
        {
            var result = new StringBuilder();

            if (list != null && list.Any())
            {
                var notFirst = false;
                foreach (var item in list)
                {
                    if (notFirst)
                        result.Append(delimiter);                    
                    result.Append(item);
                    notFirst = true;
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Устанавливает флаг
        /// </summary>
        /// <param name="value">Где установить</param>
        /// <param name="flag">Флаг</param>
        /// <param name="set">True - установить, false - сбросить</param>
        /// <returns></returns>
        public static long SetFlag(this long value, long flag, bool set)
        {
            return value & (~flag) | ((set) ? flag : 0);
        }

        /// <summary>
        /// Проверяет установку флага роли
        /// </summary>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static bool IsFlagSet(this Int64 value, long flag)
        {
            return (value & flag) != 0;
        }

        /// <summary>
        /// Проверяет установку флага роли
        /// </summary>
        /// <param name="value"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static bool IsFlagSet(this Int64 value, UserRoles flag)
        {
            return IsFlagSet(value, (long) flag);
        }

        public static string QuantityPresenter(decimal? quantity, bool alwaysShowQuantity)
        {
            if (quantity.HasValue) {
                if (alwaysShowQuantity && quantity > 0) return quantity.Value.ToString(CultureInfo.InvariantCulture);
                if (quantity > MaxVisibleQnt)
                    return $"> {MaxVisibleQnt}";
                if (quantity == -1)
                    return "0"; //ViewRes.SharedResources.No;
                if (quantity == 0)
                    return SharedResources.IsAbsent;
                return ((int)quantity).ToString();
            }
            return SharedResources.Ordering;
        }

        public static string QuantityDigitalPresenter(decimal? quantity, bool alwaysShowQuantity)
        {
            if (quantity.HasValue)
            {
                if (alwaysShowQuantity && quantity > 0) return quantity.Value.ToString(CultureInfo.InvariantCulture);
                if (quantity > MaxVisibleQnt)
                    return $"> {MaxVisibleQnt}";
                if (quantity <= 0)
                    return "0"; 
                return ((int)quantity).ToString();
            }
            return "0";
        }

        /// <summary>
        /// Преобразовывает дату поставки в срок поставки
        /// </summary>
        /// <param name="deliveryTerm"></param>
        /// <returns></returns>
        public static string DeliveryTermPresentator(DateTime? deliveryTerm)
        {
            if (deliveryTerm == null)
                return "";
            if (deliveryTerm <= DateTime.Now) 
                return SharedResources.OnStock;
            var diff = (deliveryTerm - DateTime.Now);
            var days = diff.Value.Days;
            if (days > 0)
                return $"{days} {SharedResources.days}";
            return string.Format("{0} " + SharedResources.hours, (diff.Value.Hours*60+diff.Value.Minutes - 4) / 60 + 1);
        }

        public static string HideQuotes(this string str)
        {
            //return str.Replace("\"", "#@@#").Replace("'", "#@#");
            return str.ToHex();
        }

        public static string RestoreQuotes(this string str)
        {
            //return str.Replace("#@@#", "\"").Replace("#@#", "'");
            return str.FromHex();
        }

        public static string FromHex (this string str)
        {
            string result = "";
            for (var i = 0; i < str.Length; i+=2)
            {
                result += $"{int.Parse("0x" + str.Substring(i, 2)):c}";
            }
            return result;
        }

        public static string ToHex (this string str)
        {
            return str.Aggregate("", (current, c) => current + $"{(int) c:x2}");
        }

        public static T GetItemInTreeById<T>(IEnumerable<T> items, string id)
            where T : class, ITreeComposite<T>
        {
            //if (!id.HasValue)
            //{
            //    throw new ArgumentNullException("id");
            //}

            T result = default(T);

            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    result = item;
                    break;
                }

                result = GetItemInTreeById(item.Children, id);

                if (result != null)
                {
                    break;
                }
            }

            return result;
        }

        public static T GetItemInTreeByURL<T>(IEnumerable<T> items, string url)
            where T : class, ITreeComposite<T>
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            url = url.Trim("_/").ToLower();

            var result = default(T);

            foreach (var item in items)
            {
                if (item.Url.ToLower().Trim() == url || item.Id.Trim() == url)
                {
                    result = item;
                    break;
                }

                result = GetItemInTreeByURL(item.Children, url);

                if (result != null)
                {
                    break;
                }
            }

            return result;

            //var urlParts = URL.Split(new[] { '_', '/' });
            //var urlPart = urlParts[0];
            //if (string.IsNullOrEmpty(URL))
            //{
            //    throw new ArgumentNullException("URL");
            //}

            //T result = default(T);

            //foreach (var item in items)
            //{
            //    if (item.URL == urlPart)
            //    {
            //        result = item;
            //        break;
            //    }
            //}
            //if (result != null && urlParts.Length > 1)
            //{
            //    URL = URL.Substring(urlPart.Length + 1);
            //    result = GetItemInTreeByURL(result.Children, URL);
            //}

            //return result;
        }

        public static string Trim(this string source, string trimString)
        {
            if (source == null || trimString == null)
            {
                return null;
            }

            char[] trimChars = trimString.ToCharArray();

            return source.Trim(trimChars);
        }

        public static string TrimEnd(this string source, string trimString)
        {
            if (source == null || trimString == null)
            {
                return null;
            }

            char[] trimChars = trimString.ToCharArray();

            return source.TrimEnd(trimChars);
        }

        public static string TrimStart(this string source, string trimString)
        {
            if (source == null || trimString == null)
            {
                return null;
            }

            char[] trimChars = trimString.ToCharArray();

            return source.TrimStart(trimChars);
        }

        public static string[] Split(this string source, string pattern)
        {
            if (source == null || pattern == null)
            {
                return null;
            }

            var regExp = new Regex(pattern);

            return regExp.Split(source);
        } 

        public static string RemoveBadURLSymbols(string url, bool replaceUnderscore)
        {
            var normUrl = url.Replace("/", "~").Replace("&", "'n'").Replace("+", "'plus'");
            return Uri.EscapeDataString (normUrl);
        }

        public static string RestoreBadUrlSymbols(string url)
        {
            return url?.Replace("~", "/").Replace("'n'", "&").Replace("'plus'", "+");
        }

        public static string RemoveBadURLSymbolsFull(string url, bool replaceUnderscore)
        {
            return Regex.Replace(url, replaceUnderscore ? @"[\s|&|=|/|:|\?|\.|,|_|+|*|\\|'|#|;|@|`]+" : @"[\s|&|=|/|:|\?|\.|,|+|*|\\|'|#|;|@|`]+", "-");
        }

        public static string HashSha1(this string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        public static int CalculateSha1(int number, int digits = 2)
        {
            byte[] buffer = BitConverter.GetBytes(number);
            var l = buffer.Length;
            var reversedBuffer = new byte [l];
            for (int i = 0; i < l; i++)
                reversedBuffer[i] = buffer[l - 1 - i];
            var cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            var hash = cryptoTransformSha1.ComputeHash(reversedBuffer);
            var aBase = ((int) Math.Pow(10, digits));
            for (int i = 0; i < l; i++)
                reversedBuffer[i] = hash[hash.Length - 1 - i];
            var resultByte = Math.Abs(BitConverter.ToInt32(reversedBuffer, 0)) % aBase;
            return resultByte;
        }

        public static IEnumerable<string> GetImageFileList(string path)
        {
            string[] imageTypes = {".png", ".jpg", ".gif"};
            return Directory.GetFiles(path).Select(i=>Path.GetFileName(i)).Where(i => imageTypes.Contains((Path.GetExtension(i) ?? "").ToLower())).OrderBy(i=>i);
        }

        public static string EncodeToBase64(string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeBase64(this string toDecode)
        {
            var returnValueAsBytes = Convert.FromBase64String(toDecode);
            string returnValue = Encoding.ASCII.GetString(returnValueAsBytes);

            return returnValue;
        }
    }
}
