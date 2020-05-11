using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EU_Work.Pages.Email;
using EU_Work.Pages.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;

namespace EU_Work.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ApplicationContext _context;

        public EmailController(IEmailConfiguration emailConfiguration, ApplicationContext context)
        {
            _emailConfiguration = emailConfiguration;
            _context = context;
        }

        [HttpPost]
        [ActionName("taks")]
        public async Task<IActionResult> TaksFormData(TaksForm data)
        {
            try
            {

                foreach (WorkInfo c in data.Works)
                    c.taksForm = data;

                data.dateTime = DateTime.Now;

                await _context.AddAsync<TaksForm>(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }

            return await SendEmail("New TAKS form, by " + data.name, data.ToString());
        }

        [HttpPost]
        [ActionName("work")]
        public async Task<IActionResult> WorkFormData(WorkForm data)
        {
            try
            {

                foreach (EducationInfo c in data.educations)
                    c.workForm = data;

                data.dateTime = DateTime.Now;

                await _context.AddAsync<WorkForm>(data);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return await SendEmail("New WORK form, by "+data.name, data.ToString() );
        }

        private async Task<IActionResult> SendEmail(string title, string text) {
            string emailBody = string.Empty;
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(_emailConfiguration.DestinationName, _emailConfiguration.DestinationEmail));
            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpEmail));
            message.Subject = title;
            try
            {
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = text
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