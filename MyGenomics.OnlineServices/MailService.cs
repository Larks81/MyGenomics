using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MyGenomics.OnlineServices
{
    public static class MailService
    {
        public static void SendMail(string fromAddress, string toAddress, string subject, string htmlBody)
        {
            string smtpServer = ConfigurationSettings.AppSettings.Get("smtpServer");
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = htmlBody;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(smtpServer);            
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                
            }              
        }
    }
}