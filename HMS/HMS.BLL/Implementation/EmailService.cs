using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace HMS.BLL.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public void sendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            send(emailMessage);
        }

       

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message?.Content };
            return emailMessage;
        }
        private void send(MimeMessage mailMessage)
        {
           using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                client.Send(mailMessage);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
