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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailConfiguration _emailConfiguration;

        public EmailController(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        [HttpPost]
        [ActionName("taks")]
        public async Task<IActionResult> TaksFormData(TaksFormDTO data)
        {
           
            string emailBody = string.Empty;
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(_emailConfiguration.DestinationName, _emailConfiguration.DestinationEmail));
            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpEmail));
            message.Subject = "New taks from " + data.sname;
            try
            {
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = data.ToString()
                };
            }
            catch (Exception)
            {
                return BadRequest("server reading form");
            }
            try
            {
                using (var emailClient = new SmtpClient())
                {
                    
                    await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    await emailClient.AuthenticateAsync(_emailConfiguration.SmtpEmail, _emailConfiguration.SmtpPassword);
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception) {
                return BadRequest("server error sending");
            }

            return Ok();
        }

        [HttpPost]
        [ActionName("work")]
        public async Task<IActionResult> WorkFormData(WorkFormDTO data)
        {
            string emailBody = string.Empty;
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(_emailConfiguration.DestinationName, _emailConfiguration.DestinationEmail));
            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpEmail));
            message.Subject = "New work form from " + data.sname;
            try
            {
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = data.ToString()
                };
            }
            catch (Exception)
            {
                return BadRequest("server reading form");
            }
            try
            {
                using (var emailClient = new SmtpClient())
                {

                    await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, true);
                    await emailClient.AuthenticateAsync(_emailConfiguration.SmtpEmail, _emailConfiguration.SmtpPassword);
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                return BadRequest("server error sending");
            }
            return Ok();
        }
    }
}