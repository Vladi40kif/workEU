using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EU_Work.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        public IActionResult Send()
        {
            //instantiate a new MimeMessage
            string emailBody = string.Empty;
            bool useEmailTemplate = true;
            //instantiate a new MimeMessage
            var message = new MimeMessage();

            //Setting the To e-mail address
            message.To.Add(new MailboxAddress("pidr", "nfk.if@i.ua"));
            //Setting the From e-mail address
            message.From.Add(new MailboxAddress("Admin", "workeumail@ukr.net"));
            //E-mail subject 
            message.Subject = "pizdec";
            //E-mail message body
            if (useEmailTemplate)
            {
                emailBody = "oKurva";
            }
            else
            {
                emailBody = "oKurva";

            }
            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = emailBody
            };

            //Configure the e-mail
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.ukr.net", 465, true);
                emailClient.Authenticate("workeumail@ukr.net", "wTkb3TIscVkmNDCT");
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }

            //wTkb3TIscVkmNDCT

            return Ok();
        }
    }
}