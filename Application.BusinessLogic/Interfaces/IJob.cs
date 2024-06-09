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
        List<Job> GetJobs(JobFilters filter);
        List<Job> GetUserJobs(string email);
        SimpleResponse ApplyToJobAction(int jobId, int userId, string message);
        Job GetJobByIdAction(int Id);
        List<JobApplication> GetJobApplicationAction(int jobId);
        SimpleResponse ScheduleFeedbackAction(int userId, int jobId, string date, string time, string location);
        SimpleResponse SendFeedbackAction(int userId, int jobId);
    }
}
