using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Backend.Interface;
using Microsoft.AspNetCore.Http;

namespace Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendEmailAsync(string anrede, string vorName, string nachName, string absenderEmail, string nachricht)
        {
            var smtpHost = _configuration.GetValue<string>("EMAIL_CONFIGURATION:SMTP_HOST");
            var smtpServerEmail = _configuration.GetValue<string>("EMAIL_CONFIGURATION:SMTP_EMAIL");
            var password = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var smtpClient = new SmtpClient(smtpHost, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpServerEmail, password)
            };

            // Vordefinierte Werte
            string empfaengerEmail = "dejan@busi.dev";
            string betreff = "Kontaktanfrage von der Galerie";

            var message = new MailMessage
            {
                From = new MailAddress(smtpServerEmail, $"{anrede} {vorName} {nachName}"),
                Subject = betreff,
                Body = nachricht,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(empfaengerEmail));
            message.ReplyToList.Add(new MailAddress(absenderEmail));

            await smtpClient.SendMailAsync(message);
        }
    }
}
