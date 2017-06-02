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
            //var companyMail = "mailname@site.com";
            //var password = "pas$w0rd#";";

            smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.zoho.eu";
            smtpClient.Port = 465;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 2 * 60 * 1000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(companyMail, password);

            message = new MailMessage();
            message.From = new MailAddress(companyMail);
            message.IsBodyHtml = true;
        }

        public void Send(CartDTO cart)
        {
            message.To.Add(cart.Email);
            message.Subject = "Store application: shopping cart";

            var carts = "";
            var sum = 0m;
            foreach (var item in cart.Products)
            {
                if (cart.Promocode == null)
                {
                    carts += item.Name + ": " + item.Price + "<br/>";
                    sum += item.Price;
                }
                else
                {
                    carts += item.Name + ": " + item.SalePrice + "<br/>";
                    sum += item.SalePrice;
                }
            }

            message.Body = "Hello!<br/><br/>Your shopping cart:<br/>" + carts + "<hr/>Total:" + sum;
            message.Body += string.IsNullOrEmpty(cart.Promocode) ? "<br/><br/>--<br/>Best regards, Store team." : "Used promocode: " + cart.Promocode + "<br/><br/>--<br/>Best regards, Store team.";

            smtpClient.Send(message);
        }
    }
}