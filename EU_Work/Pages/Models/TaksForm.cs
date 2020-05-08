
using EU_Work.Pages.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EU_Work.Pages.Models
{
    public class TaksForm : TaksFormDTO
    {
        [Key]
        public int id { get; set; }
        public DateTime dateTime { get; set; }

    }
}
