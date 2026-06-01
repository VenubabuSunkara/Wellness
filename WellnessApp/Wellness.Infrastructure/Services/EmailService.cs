using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Wellness.Application.Interfaces;

namespace Wellness.Infrastructure.Services
{
    public class EmailService(IConfiguration configuration) : IEmailService
    {
        private readonly IConfiguration _configuration = configuration;

        public Task SendEmailAsync(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient(_configuration["Email:SmtpHost"])
            {
                Port = int.Parse(_configuration["Email:Port"]!),

                Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),

                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Email:From"]!),

                Subject = subject,

                Body = body,

                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            return smtpClient.SendMailAsync(mailMessage);
        }
    }
}