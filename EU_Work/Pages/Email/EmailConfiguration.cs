using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EU_Work.Pages.Email
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }
        public string SmtpEmail { get; set; }
        public string SmtpPassword { get; set; }
        public string DestinationEmail { get; set; }
        public string DestinationName { get; set; }
        public bool SmtpSSLFlag { get; set; }
    }
}
