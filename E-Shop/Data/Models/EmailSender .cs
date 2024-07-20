using E_Shop.Data.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace E_Shop.Data.Models
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail()
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("rp63325@gmail.com","");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("rp63325@gmail.com");
            mailMessage.To.Add("rahulpatel02030@gmail.com");
            mailMessage.Subject = "Testing"; 
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
    }
}
