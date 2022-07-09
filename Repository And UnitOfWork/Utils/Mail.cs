using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Repository_And_UnitOfWork.Utils
{
    public class MailSetting
    {
        public string FromEmailAddress { get; set; }
        public string FromEmailDisplayName { get; set; }
        public string FromEmailPassword { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPPort { get; set; }
    }

    public class Mail: IEmailSender
    {
        private MailSetting mailSetting { get; set;}
        public Mail(IOptions<MailSetting> _mailSettings)
        {
            mailSetting = _mailSettings.Value;
        }
        public async Task SendEmailAsync(string toEmailAddress, string subject, string body)
        {
            try
            {
                // MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(mailSetting.FromEmailAddress, mailSetting.FromEmailDisplayName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                message.To.Add(new MailAddress(toEmailAddress));

                SmtpClient client = new SmtpClient
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mailSetting.FromEmailAddress, mailSetting.FromEmailPassword),
                    Host = mailSetting.SMTPHost,
                };
                await client.SendMailAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
