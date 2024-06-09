using System.Collections.Generic;
using System.Web.Mvc;
using Application.Domain.Entities.Job;
using Application.Models.User;

namespace Application.Models.Job
{
    public class JobsListViewModel
    {
        public UserData user { get; set; }
        public List<Application.Domain.Entities.Job.Job> jobs;
        public Application.Domain.Entities.Job.JobFilters filter { get; set; } = new Application.Domain.Entities.Job.JobFilters();

        public JobsListViewModel()
        {
            filter = new Domain.Entities.Job.JobFilters
            {
                minSalary = null,
                maxExperience = null,
                workMode = null,
            };
        }
    }
}