using Application.BusinessLogic.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.Job
{
    public class JobFilters
    {
        public string workMode { get; set; }
        public int minSalary { get; set; }
        public int maxExperience { get; set; }
    }
}