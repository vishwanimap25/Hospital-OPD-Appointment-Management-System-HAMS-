using Hospital_OPD___Appointment_Management_System__HAMS_.Modal.Entities;
using Hospital_OPD___Appointment_Management_System__HAMS_.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;

namespace Hospital_OPD___Appointment_Management_System__HAMS_.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _email;

        public EmailService(IOptions<EmailSettings> email)
        {
            _email = email.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_email.FromEmail));
                message.To.Add(MailboxAddress.Parse(toEmail));
                message.Subject = subject;
                message.Body = new TextPart(TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_email.SmtpHost, _email.SmtpPort, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_email.Username, _email.Password);
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email sending failed: {ex.Message}");
                throw;
            }
        }
    }
}
