using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace FanEase.Entity.Models
{
    public class SendRegisterationLink
    {
        public static int OTP;
        public static DateTime time;
        public static bool SendLink(string recipientEmail)
        {
            

            // Gmail SMTP server details
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "atulthakre897@gmail.com";
            string smtpPassword = "yfmzleuuqggjlazq";

            // Sender and recipient details
            string senderEmail = "atulthakre897@gmail.com";
            string senderName = "Admin_FanEase";

            // Create a new MailMessage
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail, senderName);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = "OTP-Restore Password";
            Random rnd = new Random();
            OTP=rnd.Next(10000);
            time = DateTime.Now.AddMinutes(1);
            
            mailMessage.Body = $"Your OTP to reset Password is : {OTP}";
            mailMessage.IsBodyHtml = true;

            // Setup the SMTP client
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            
           
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("OTP email sent successfully.");
                return true;
            
            
        }

        public static bool SendCredentials(CredentialVM credential)
        {
            // Gmail SMTP server details
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "atulthakre897@gmail.com";
            string smtpPassword = "yfmzleuuqggjlazq";

            // Sender and recipient details
            string senderEmail = "atulthakre897@gmail.com";
            string senderName = "Admin_FanEase";

            // Create a new MailMessage
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail, senderName);
            mailMessage.To.Add(credential.Email);
            mailMessage.Subject = "Creator Login Credentials";
           
            mailMessage.Body = $"UserName : {credential.Email}" +" "+
                $"Password : {credential.Password}";
            mailMessage.IsBodyHtml = true;

            // Setup the SMTP client
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;



            // Send the email
            smtpClient.Send(mailMessage);
            Console.WriteLine("Credential email sent successfully.");
            return true;
        }

    }
}
