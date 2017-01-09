using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowmuWeb.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();

            //emailMessage.From.Add(new MailboxAddress("tianwei blogs", "mail@hantianwei.cn"));
            //emailMessage.To.Add(new MailboxAddress("mail", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart("plain") { Text = message };

            //using (var client = new SmtpClient())
            //{
            //    await client.ConnectAsync("smtp.hantianwei.cn", 25, SecureSocketOptions.None).ConfigureAwait(false);
            //    await client.AuthenticateAsync("mail@hantianwei.cn", "******");
            //    await client.SendAsync(emailMessage).ConfigureAwait(false);
            //    await client.DisconnectAsync(true).ConfigureAwait(false);

            //}
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
