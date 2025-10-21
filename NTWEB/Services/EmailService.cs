using MailKit.Net.Smtp;
using MimeKit;
using NTWEB._01_Framework;

namespace NTWEB.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string type, string fromEmail, string name, string subject, string message)
        {
            var mailName = "NTWEB-" + type;

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(mailName, Variables.Email));
            email.To.Add(MailboxAddress.Parse(Variables.Email));
            email.ReplyTo.Add(new MailboxAddress(name, fromEmail));
            email.Subject = $"{mailName}: {subject}";

            email.Body = new TextPart("plain")
            {
                Text = $"From: {name}\nEmail: {fromEmail}\n\nMessage: {message}"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(Variables.Email, Variables.AppPassword);
            await client.SendAsync(email);
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}
