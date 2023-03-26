using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MimeKit;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Text;
using log4net;
using log4net.Config;
using System.Net;
using MailKit.Security;
using System.Net.Mail;
using ValmiStore.Model.Entities.Cms.AutoService;
using Webmall.Model.Entities.Cms;
using Webmall.Model.Entities.Cms.NewsData;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model
{

    /// <summary>
    /// Вспомогательный класс по рассылке сообщений
    /// </summary>
    public class MailHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MailHelper));

        public static UrlHelper Url = null;

        private static IUserRepository UserRepository => DependencyResolver.Current.GetService<IUserRepository>();
        private static ICmsRepository CmsRepository => DependencyResolver.Current.GetService<ICmsRepository>();

        static MailHelper()
        {
            XmlConfigurator.Configure();
        }
        public static void SendMailMessage(string toAddresses, MailMessage mail, string bccAddress = null)
        {
            if (mail == null || string.IsNullOrEmpty(toAddresses))
                return;
            SendMailMessage(toAddresses.Split(',', ';', ' '), mail, bccAddress);
        }
        public static void SendMailMessage(string[] toAddresses, MailMessage mailMessage, string bccAddress = null)
        {
            var mail = (MimeMessage)mailMessage;

            if (mail == null || toAddresses == null)
                return;

            if (mail.From.Count == 0)
            {
                mail.From.Add(new MailboxAddress(ConfigHelper.MailFromName ?? ConfigHelper.EmailUserName, ConfigHelper.MailFromAddress ?? ConfigHelper.EmailUserName));
                if (!mail.From.Any())
                {
                    var msg = "SendMailMessage. Не задан адрес отправки сообщений.";
                    Log.Error(msg);
                    return;
                }                
            }
            if (!string.IsNullOrWhiteSpace(bccAddress))
                mail.Bcc.Add(new MailboxAddress(bccAddress, bccAddress));

            //Add one or more addresses that will receive the mail
            foreach (var addr in toAddresses)
            {
                mail.To.Clear();
                var addrTrimmed = addr.Trim();
                if (!string.IsNullOrEmpty(addrTrimmed))
                {
                    mail.To.Add(new MailboxAddress(addrTrimmed, addrTrimmed));
                    Log.Debug("Added addr: " + addrTrimmed);
                    try
                    {
                        using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
                        {
                            smtpClient.CheckCertificateRevocation = false;
                            if(ConfigHelper.EmailServerSSLEnable)
                            {
                                smtpClient.SslProtocols = System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls12;
                                smtpClient.Connect(ConfigHelper.EmailServerAddress, ConfigHelper.EmailSMTPSPort, SecureSocketOptions.Auto);
                            }
                            else
                            {
                                smtpClient.Connect(ConfigHelper.EmailServerAddress, ConfigHelper.EmailSMTPSPort);
                            }
                            smtpClient.Authenticate(new NetworkCredential(ConfigHelper.EmailUserName, ConfigHelper.EmailPassword));
                            smtpClient.Send(mail);
                            smtpClient.Disconnect(true);
                            Log.Debug($"\nSent to: {string.Join(",", mail.To.Select(i => i.Name))}, Subj: {mail.Subject}");
                        }
                    }
                    catch (Exception e)
                    {
                        Log.Error(string.Join(";", e.Message, e.InnerException?.Message)
                            + "\nSent to: " + string.Join(",", mail.To.Select(i => i.Name))
                            + "\nFrom: " + string.Join(",", mail.From.Select(i=>i.Name))
                            + "\nReply to: " + string.Join(",", mail.ReplyTo.Select(i => i.Name))
                            );
                    }
                }
            }
        }
        public static void SendRegistrationConfirmation(User user, string url)
        {
            SendMailMessage(user.Email, Msg2Mail(MailMessages.RegistrationConfirmationRequest, new { url, password = user.Password }));
        }

        public static void SendJuridicalRegistrationInfo(UserRegistrationData user)
        {
            SendMailMessage(ConfigHelper.JuridicalRegistrationReceivers, Msg2Mail(MailMessages.MsgJuridicalRegistrationInfoMessage,
                new
                {
                    login = user.Login,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    juridicalname = user.JuridicalName,
                    juridicaladdress = user.JuridicalAddress,
                    fiscalcode = user.FiscalCode,
                    mobilephone = user.PhoneMobile,
                    fixedphone = user.PhoneHome,
                    bankaccount = user.BankAccount,
                    bankcode = user.BankCode,
                    tvapayer = user.ImTVAPayer,
                    tvapayercode = user.TVAPayerCode
                }));
        }

        public static void SendPhisicalRegistrationInfo(User user)
        {
            SendMailMessage(ConfigHelper.PhisicalRegistrationReceivers, Msg2Mail(MailMessages.MsgPhisicalRegistrationInfoMessage,
                new
                {
                    login = user.Login,
                    firstname = user.FirstName,
                    lastname = user.LastName,                    
                    address = user.Address,                    
                    mobilephone = user.PhoneMobile,
                    fixedphone = user.PhoneHome
                }));
        }

        public static void SendMessageToManager(string mailaddress, string name, string message, MemoryStream stream = null, string fileName = null)
        {
            try
            {
                MimeKit.AttachmentCollection attachments = null;
                if (stream != null && !string.IsNullOrEmpty(fileName))
                {
                    attachments = new MimeKit.AttachmentCollection();
                    attachments.Add(fileName, stream);
                }

                var mail = Msg2Mail(MailMessages.MsgUserMessage, new { fio = name, email = mailaddress, message, attachments });

                if (!string.IsNullOrWhiteSpace(mailaddress) && mailaddress.Contains('@'))
                    mail.From = new MailAddress(mailaddress, name);
                else
                    mail.From = new MailAddress(ConfigHelper.MailFromAddress, name + "(тел. " + mailaddress + ")");
                SendMailMessage(CmsRepository.GetCallManagersMails(), mail);
            }
            catch (Exception e)
            {
                Log.Error(e.Message + "\nSendMessageToManager from: " + mailaddress);
            }
        }

        public static void SendCatalogErrorMessage(User user, int wareId, string wareNum, string message)
        {
            string mailaddress = ConfigHelper.MistakeMessageReceivers;
            var mail = Msg2Mail(MailMessages.MsgUserMessage, new { fio = user.FullName, email = user.Email, position_code = wareId, catalog_number = wareNum, message });
            //mail.From = new MailAddress(mailaddress, user.FIO);
            SendMailMessage(mailaddress/*UserRepository.GetCallManagersMails()*/, mail);
        }

        public static void SendSimpleMessage(string message, string subject, string email)
        {
            string mailaddress = email;
            var mail = new MailMessage { Subject = subject, Body = message };
            SendMailMessage(mailaddress, mail);
        }

        /// <summary>
        /// Сообщение рассылки о новых/изменившихся предложениях
        /// </summary>
        /// <param name="news">Данные предложения</param>
        /// <param name="subscriptionData">Данные пользователя</param>
        /// <param name="isPromotion">true - Акция, false - новость</param>
        public static void SendPromotionSubscriptionMessage(NewsArticle news, User subscriptionData, bool isPromotion)
        {
            string mailaddress = subscriptionData.Email; // "ShowSingleNews", "News", new { id = newsId })
            var url = (string.IsNullOrEmpty(ConfigHelper.BaseUrl)) ? "" : ConfigHelper.BaseUrl.Trim('/') + "/" + (isPromotion ? "News" : "Promotions") + "/Show/"
                + (!string.IsNullOrWhiteSpace(news.Url) ? news.Url : news.Id.ToString(CultureInfo.InvariantCulture));
            var unsubscribeurl = (string.IsNullOrEmpty(ConfigHelper.BaseUrl)) ? "" : ConfigHelper.BaseUrl.Trim('/') + "/Security/EditPersonalData";
            var mail = Msg2Mail(MailMessages.MsgPromotionSubscriptionMessage,
                new
                {
                    fio = subscriptionData.FullName,
                    email = subscriptionData.Email,
                    title = news.Header,
                    url,
                    unsubscribeurl,
                    article = news.FullText.ToString().Replace("/UserFiles/", ConfigHelper.BaseUrl.Trim('/') + "/UserFiles/")
                });
            SendMailMessage(mailaddress, mail);
        }

        public static void SendVINRequestMessage(User user, VINRequest request)
        {
            IVinRequestRepository vinRequestRepository = DependencyResolver.Current.GetService<IVinRequestRepository>();
            string mailaddress = vinRequestRepository.GetVINRequestManagersMails();
            var mail = Msg2Mail(MailMessages.MsgRequestByVin, new { fio = user.FullName, email = user.Email, marka = request.MarkaName, model = request.ModelName });
            //mail.From = new MailAddress(user.Email, user.FIO);
            SendMailMessage(mailaddress, mail);
        }

        public static void SendVINRequestAnswerMessage(User user, VINRequest request)
        {
            var client = UserRepository.GetUser(request.UserId.ToString());
            string mailaddress = client?.Login;

            var mail = Msg2Mail(MailMessages.MsgRequestByVin, new { fio = client?.FullName, email = client?.Email, phone = ConfigHelper.TitleHelpPhone, marka = request.MarkaName, model = request.ModelName });

            Log.Debug($"SendVINRequestAnswerMessage to user {{userId:{request.UserId}, mail: {mailaddress}, mail: {mail?.Subject}}}");
            SendMailMessage(mailaddress, mail);
        }

        public static void SendNewRepresentationNotification(User user, string clientCode, string clientName, IEnumerable<User> receivers)
        {
            SendMailMessage(GetMailList(receivers), Msg2Mail(MailMessages.MsgRepresenterRegistrationRequest,
                new { fio = user.LastName + " " + user.FirstName, email = user.Email, client_code = clientCode, client_name = clientName }));
        }

        public static void SendRepresentationConfirmationNotification(User user, string clientCode, string clientName, IEnumerable<User> receivers)
        {
            SendMailMessage(GetMailList(receivers), Msg2Mail(MailMessages.MsgRepresentationRequestConfirmationMessage,
                new { fio = user.LastName + " " + user.FirstName, email = user.Email, client_code = clientCode, client_name = clientName }));
        }
        public static void SendServiceBookingRequest(string clientName, string email, AutoServiceInfo serviceInfo, string marka, string model, string year, string engine, string phone, string date, string time, string descr, string vinCode, string carNumber)
        {
            string mailaddress = serviceInfo.Email;
            if (string.IsNullOrWhiteSpace(mailaddress))
                mailaddress = ConfigHelper.BookingRequestManager;
            var mail = Msg2Mail(MailMessages.MsgServiceBookingRequest, new { fio = clientName, email, servicename = serviceInfo.Name, marka, model, year, engine, phone, date, time, descr, vinCode, carNumber });
            SendMailMessage(mailaddress, mail);
        }

        public static void SendCongratulationMessage(User user, string html, string orderNum)
        {
            var mail = Msg2Mail(html, null);
            mail.Subject = ViewRes.SharedResources.Order + " # " + orderNum;
            SendMailMessage(GetMailList(new[] { user }), mail);
        }

        public static void SendCongratulationMessage(string email, string html, string orderNum)
        {
            var mail = Msg2Mail(html, null);
            mail.Subject = ViewRes.SharedResources.Order + " # " + orderNum;
            SendMailMessage(email, mail);
        }

        public static void SendCongratulationMessageCopy(string address, string html)
        {
            if (!string.IsNullOrWhiteSpace(address))
                SendMailMessage(address, Msg2Mail(html, null));
        }

        public static MailMessage Msg2Mail(MailMessages message, object parameters)
        {
            var messageTemplate = CmsRepository.GetMailMessageTemplate(message);
            if (messageTemplate == null)
                return null;
            return Msg2Mail(messageTemplate.Text, parameters);
        }

        public static MailMessage Msg2Mail(string msg, object parameters)
        {
            //Create the mail message
            var subj = Regex.Match(msg, "@{SUBJECT:.+}").Value;
            msg = Regex.Replace(msg, "@{SUBJECT:.+}", "");
            msg = FormatString(msg, parameters);
            if (!string.IsNullOrEmpty(subj)) subj = FormatString(subj.Substring(10, subj.Length - 11), parameters);
            var mail = new MailMessage
            {
                Subject = subj,
                Body = msg,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8
            };
            return mail;
        }

        public static string FormatString(string msg, object parameters)
        {
            if (msg != null)
            {
                if (parameters != null)
                {
                    foreach (var prop in parameters.GetType().GetProperties())
                    {
                        var propName = prop.Name;
                        msg = Regex.Replace(msg, "@{" + propName.ToUpper() + "}",
                                            (prop.GetValue(parameters, null) ?? "").ToString());
                    }
                }
                msg = Regex.Replace(msg, "@{.+}", "");
            }
            return msg;
        }

        private static string GetMailList(IEnumerable<User> list)
        {
            var mail = new StringBuilder();
            foreach (var item in list)
                mail.Append("," + item.Email);

            if (mail.Length > 0)
                return mail.ToString().Substring(1);
            return null;
        }
    }
}
