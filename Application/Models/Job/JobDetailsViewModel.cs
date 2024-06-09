using Application.BusinessLogic.Core;
using Application.Domain.Entities.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.Job
{
    public class JobDetailsViewModel
    {

        public Application.Domain.Entities.Job.Job job { get; set; }
        public List<Application.Domain.Entities.Job.JobApplication> applications { get; set; }
    }
}