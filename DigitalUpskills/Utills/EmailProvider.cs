using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DigitalUpskills.Utills
{
    public static class EmailProvider
    {
        public static void Email(string recieverEmail, string emailSubject, string mailBody)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("dodomaster52@gmail.com");
                message.To.Add(new MailAddress("recieverEmail"));
                message.Subject = "emailSubject";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = mailBody;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("dodomaster52@gmail.com", "sinannaina");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) {}
        }
    }
} 