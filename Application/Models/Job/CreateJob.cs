using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml.Linq;


namespace Application.Models.Job
{
    public class CreateJobModel
    {
        [Required(ErrorMessage = "Company name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Vacancy is required")]
        public string Vacancy { get; set; }

        [Required(ErrorMessage = "Work Mode is required")]
        public string WorkMode { get; set; }

        [Required(ErrorMessage = "Summary is required")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Minimal experience is required")]
        public int MinExp { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
    }
}