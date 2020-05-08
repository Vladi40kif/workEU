using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EU_Work.Pages.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        DbSet<TaksForm> TaksForms { get; set; }
        DbSet<WorkForm> WorkForms { get; set; }
        DbSet<EducationInfo> EducationInfo { get; set; }
        DbSet<WorkInfo> WorkInfo { get; set; }
    }
}
