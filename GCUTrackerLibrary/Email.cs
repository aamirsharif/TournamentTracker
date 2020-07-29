using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace GCUTrackerLibrary
{
    class Email
    {
        /// <summary>
        /// Sends email to provided sender.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void sendEmail(string to, string subject, string body)
        {
            sendEmail(new List<string> { to }, new List<string> { }, subject, body);
        }

        /// <summary>
        /// Send email to provided persons including bcc's.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="bcc"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void sendEmail(List<string> to,List<string> bcc,string subject,string body)
        {
            //Get the sender mail address and name from app.config
            MailAddress from = new MailAddress(ConfigurationManager.AppSettings["senderEmail"], ConfigurationManager.AppSettings["senderName"]);
            
            //Create a mail object
            MailMessage mail = new MailMessage();
            
            //Add all the recievers in the mail
            foreach(string email in to)
            {
                mail.To.Add(email);
            }
            
            //Add all the bcc's in the mail
            foreach(string email in bcc)
            {
                mail.Bcc.Add(email);
            }

            mail.From = from;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //Create smtp client and send the mail
            SmtpClient client = new SmtpClient();
            client.Send(mail);
        }
    }
}
