using System.IO;
using System.Net;

namespace Webmall.Model
{
    public class PostHelper
    {
        public static Stream GetPostStream(string url)
        {
            Stream newStream = null;

            try
            {
                var req = WebRequest.Create(url);
                //req.Proxy = new WebProxy("http://192.168.11.10:3128/");
                req.Method = "GET";
                req.Timeout = 120000;
                // эта строка необходима только при защите скрипта на сервере Basic авторизацией
                //req.Credentials = new NetworkCredential("login", "password");

                //req.ContentType = "application/x-www-form-urlencoded";
                //var someBytes = new byte[] { 48 };

                // передаем список пар параметров / значений для запрашиваемого скрипта методом POST
                // в случае нескольких параметров необходимо использовать символ & для разделения параметров
                // в данном случае используется кодировка windows-1251 для Url кодирования спец. символов значения параметров
                //SomeBytes = Encoding.GetEncoding(1251).GetBytes("ID=" + HttpUtility.UrlEncode("10", Encoding.GetEncoding(1251)));
//                req.ContentLength = someBytes.Length;
//                newStream = req.GetRequestStream();
//                newStream.Write(someBytes, 0, someBytes.Length);
//                newStream.Close();

                // считываем результат работы
                var result = req.GetResponse();
                return result.GetResponseStream();
            }
            finally
            {
                if (newStream != null)
                    newStream.Close();
            }
        }

    }
}
