using System.Collections.Generic;
using Application.Domain.Entities.Job;

namespace Application.Models.Job
{
    public class JobsListViewModel
    {
        public List<Application.Domain.Entities.Job.Job> jobs;
        public Application.Domain.Entities.Job.JobFilters filter { get; set; } = new Application.Domain.Entities.Job.JobFilters();
    }
}