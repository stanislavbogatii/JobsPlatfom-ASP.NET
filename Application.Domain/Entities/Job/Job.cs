﻿using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.Job
{
    public class Job
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string Vacancy { get; set; }

        [Required]
        public string WorkMode { get; set; }

        public string Summary { get; set; }

        public int MinExp { get; set; }

        public int Salary { get; set; }
        public int? ApplicationCount { get; set; }
    }
}
