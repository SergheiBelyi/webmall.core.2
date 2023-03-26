using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using Webmall.Model;

namespace Webmall.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error404(string path)
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            Response.ContentType = "text/html; charset=utf-8";
            return View("Error404"
            , new HandleErrorInfo(
                new Exception("Ошибка 404: запрошенный ресурс '" + path + "' не найден"),
                "Error",
                "Error404")
            );
        }

        public ViewResult Error500(string path)
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return View("Error");
        }

        public JsonResult SendToAdmin(string url, string data)
        {
            byte[] img = Convert.FromBase64String(data);

            string name = ConfigHelper.AccessLogPath+DateTime.Now.ToString("yyyy.MM.dd hh.mm.ss") + ".png";

            var file = new FileStream(name, FileMode.Create, FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            file.Write(img, 0, img.Length);

            // close file stream
            file.Close();
            var stream = new MemoryStream(img);
            var mail = new MailMessage { Subject = "Error500", Body = "URL: "+url};
            mail.Attachments.Add(new Attachment(stream, name));
            MailHelper.SendMailMessage(ConfigHelper.SysAdminEmail, mail);

            return Json(name);
        }
    }
}
