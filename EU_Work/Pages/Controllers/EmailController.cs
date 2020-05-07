using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EU_Work.Pages.DTOs;
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
        /// <summary>
        /// api/Email/
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult get(   )
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult WorkFormData(WorkFormDTO data)
        {
            string emailBody = string.Empty;
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress("pidr", "nfk.if@i.ua"));
            message.From.Add(new MailboxAddress("Admin", "workeumail@ukr.net"));
            message.Subject = "pizdec";

            message.Body = new TextPart(TextFormat.Plain)
            {
                Text = data.ToString()
            };
  
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