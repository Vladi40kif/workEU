using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EU_Work.Pages.Email
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }
        int SmtpPort { get; }
        string SmtpUsername { get; set; }
        string SmtpEmail { get; set; }
        string SmtpPassword { get; set; }
        public string DestinationEmail { get; set; }
        public string DestinationName { get; set; }
        public bool SmtpSSLFlag { get; set; }

    }
}
