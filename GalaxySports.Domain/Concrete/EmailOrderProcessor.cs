using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using GalaxySports.Domain.Abstract;
using GalaxySports.Domain.Entities;

namespace GalaxySports.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "big-r2008@yandex.ru";
        public string MailFromAddress = "dorymariev@mail.ru";
        public bool UseSsl = true;
        public string UserName = "dorymariev@mail.ru";
        public string Password = "dima11111990122448";
        public string ServerName = "smtp.mail.ru";
        public int ServerPort = 2525;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\galaxy_sports_emails";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(IOrderRepository orderRepository, IOrderProductRepository orderProductRepository, Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})\n", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:c}\n", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(string.Format("Name: {0}", shippingInfo.Name))
                    .AppendLine(string.Format("Phone: {0}", shippingInfo.PhoneNumber))
                    .AppendLine(string.Format("Country: {0}", shippingInfo.Country))
                    .AppendLine(string.Format("State: {0}", shippingInfo.State ?? ""))
                    .AppendLine(string.Format("City: {0}", shippingInfo.City))
                    .AppendLine(string.Format("Address: {0}", shippingInfo.Address))
                    //.AppendLine(shippingInfo.Line2 ?? "")
                    //.AppendLine(shippingInfo.Line3 ?? "")
                    //.AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingInfo.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAddress,
                    emailSettings.MailToAddress,
                    "New order submitted!",
                    body.ToString());

                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
