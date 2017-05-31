using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using LimestoneDigitalTask.Models.DTO;

namespace LimestoneDigitalTask.Helpers
{
    public class MailsHelper
    {
        private SmtpClient smtpClient { get; set; }
        private MailMessage message { get; set; }

        public MailsHelper()
        {
            //var companyMail = "mailname@yandex.ua";
            //var password = "pas$w0rd#";
            var companyMail = "bioss-1000@yandex.ua";
            var password = "q1w2e3r4t5";

            smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.yandex.ua";
            smtpClient.Port = 25;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 2 * 60 * 1000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(companyMail, password);

            message = new MailMessage();
            message.From = new MailAddress(companyMail);
            message.IsBodyHtml = true;
        }

        public void Send(string email, List<MailCartDTO> list, string promoCode)
        {
            message.To.Add(email);
            message.Subject = "Store: shopping cart";

            var cart = "";
            var sum = 0m;
            foreach (var item in list)
            {
                cart += item.Name + ": " + item.Price + "<br/>";
                sum += item.Price;
            }

            message.Body = "Hello!<br/><br/>Your shopping cart:<br/>" + cart + "<hr/>Total:" + sum;
            message.Body += string.IsNullOrEmpty(promoCode) ? "<br/><br/>--<br/>Best regards, Store team." : "Used promocode: " + promoCode + "<br/><br/>--<br/>Best regards, Store team.";

            smtpClient.Send(message);
        }
    }
}