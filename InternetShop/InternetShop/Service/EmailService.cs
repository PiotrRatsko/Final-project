using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Service
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message, string name)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("sushimoto", ""));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "Dear " + name + ", we sent your mail back. We do not have time to read it. Your message was:" + message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 465, true);
            await client.AuthenticateAsync("motosushimoto@gmail.com", "SushiMotoStore");
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}