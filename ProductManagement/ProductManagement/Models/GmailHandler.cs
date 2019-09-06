using ProductManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProductManagement.Models
{
    public class GmailHandler : IMailActions
    {
        private string userMailId;
        private string subject;
        private string body;
        private string password;
        public GmailHandler()
        {
            userMailId = ConfigurationManager.AppSettings["userMailId"];
            subject = ConfigurationManager.AppSettings["ForgotPasswordSubject"];
        }
        public void sendMail(string emailId)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(userMailId);
            mail.To.Add(emailId);
            mail.Subject = subject;
            mail.Body = "Please use this "+ SqlDBContext.DBInstance.GetPassword(userMailId).Result + " password for login purpose.";
            password = SqlDBContext.DBInstance.GetPassword(userMailId).Result;
            SmtpServer.Port = 587;
            SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(userMailId, password);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
    }
}