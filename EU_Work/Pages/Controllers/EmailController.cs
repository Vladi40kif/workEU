using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EU_Work.Pages.DTOs;
using EU_Work.Pages.Email;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EU_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailConfiguration _emailConfiguration;

        public EmailController(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        [HttpPost]
        public IActionResult WorkFormData(WorkFormDTO data)
        {
            string emailBody = string.Empty;
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(_emailConfiguration.DestinationName, _emailConfiguration.DestinationEmail));
            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpEmail));
            message.Subject = "New work form from" + data.sname;

            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = data.ToString()
            };
  
            using (var emailClient = new SmtpClient())
                {
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                emailClient.Authenticate(_emailConfiguration.SmtpEmail, _emailConfiguration.SmtpPassword);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }

            return Ok();
        }
    }
}