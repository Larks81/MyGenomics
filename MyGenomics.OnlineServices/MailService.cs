using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MyGenomics.OnlineServices
{
    public static class MailService
    {
        public static void SendMail(string toAddress, string subject, string htmlBody)
        {
            string fromAddress = ConfigurationManager.AppSettings.Get("fromAddressNotification");
            string smtpServer = ConfigurationManager.AppSettings.Get("smtpServer");
            string smtpUsername = ConfigurationManager.AppSettings.Get("smtpUsername");
            string smtpPassword = ConfigurationManager.AppSettings.Get("smtpPassword");
            var message = new MailMessage(fromAddress, toAddress, subject, htmlBody);
            message.IsBodyHtml = true;            
            var mailClient = new SmtpClient(smtpServer);
            var cred = new NetworkCredential(smtpUsername, smtpPassword);
            mailClient.EnableSsl = false;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = cred;

            try
            {
                mailClient.Send(message);
            }
            catch(Exception ex)
            {
                
            }

            //string smtpServer = ConfigurationSettings.AppSettings.Get("smtpServer");
            //MailMessage message = new MailMessage(fromAddress, toAddress);
            //message.Subject = subject;
            //message.Body = htmlBody;
            //message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient(smtpServer);            
            //client.UseDefaultCredentials = true;

            //try
            //{
            //    client.Send(message);
            //}
            //catch (Exception ex)
            //{
                
            //}              
        }
    }
}