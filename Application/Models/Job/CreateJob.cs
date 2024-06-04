using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace Application.Models.Job
{
    public class CreateJobModel
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Vacancy { get; set; }

        [Required]
        public JobModType WorkMode { get; set; }

        public string Summary { get; set; }

        public int MinExp { get; set; }

        public int Salary { get; set; }
    }
}