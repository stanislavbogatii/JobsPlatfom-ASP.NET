using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Application.Models.Job
{
    public class CreateJob
    {
        [Required]
        [Display(Name = "Name")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mode")]
        public JobModType Mode { get; set; }

        [Display(Name = "Additional")]
        public string Additional { get; set; }

        [Display(Name = "Expirience")]
        public float Expirience { get; set; }
    }
}