using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.BusinessLogic.Interfaces
{
    public interface IJob
    {
        CreateJobResponse CreateJobAction(Job data, string ownerEmail);
        List<Job> GetJobs();
        List<Job> GetUserJobs(string email);
    }
}
