using System.IO.Enumeration;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using MimeKit;
using ShopTARge24.Core.Dto;
using MailKit.Net.Smtp;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.ApplicationServices.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;

        public EmailServices
            (
                IConfiguration config
            )
        {
            _config = config;
        }
        public void SendEmail(EmailDto dto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;

            var builder = new BodyBuilder
            {
                HtmlBody = dto.Body
            };
            
            // failide lisamine
            foreach (var file in dto.Attachment)
            {
                // kontrollib faili suurust ja siis saadab teele
                if (file.Length > 0 && file.Length < 104855760)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        ms.Position = 0;
                        builder.Attachments.Add(file.FileName, ms.ToArray());
                    }
                }
            }
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect(_config.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}

