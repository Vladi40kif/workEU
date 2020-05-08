using EU_Work.Pages.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EU_Work.Pages.Models
{
    public class WorkForm: WorkFormDTO
    {
        [Key]
        public int id { get; set; }
        public DateTime dateTime { get; set; }

    }
}
