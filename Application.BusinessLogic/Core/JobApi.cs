using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Internal;

namespace Application.BusinessLogic.Core
{
    public class JobApi
    {

        public CreateJobResponse CreateJobService(Job data, string ownerEmail)
        {
            using (var db = new UserContext())
            {
                UDbTable user = db.Users.FirstOrDefault(u => u.Email == ownerEmail);
                if (user == null)
                {
                    return new CreateJobResponse { IsSuccess = false, Msg = "Owner not found" };
                }
                var enumd = new JobModType().GetType();

                JobDbTable newJob = new JobDbTable
                {
                    CompanyName = data.CompanyName,
                    MinExp = data.MinExp,
                    Salary = data.Salary,
                    Summary = data.Summary,
                    Vacancy = data.Vacancy,
                    WorkMode = data.WorkMode.ToString(),
                    Owner = user,
                    OwnerId = user.Id
                };
                db.Jobs.Add(newJob);
                db.SaveChanges();
            }
            return new CreateJobResponse { IsSuccess = true, Msg = "success" };
        }

        public List<Job> GetJobsService(JobFilters filter)
        {
            List<JobDbTable> jobs;
            using (var db = new UserContext())
            {
                jobs = db.Jobs.Include(j => j.applications).ToList();
            }
            List<Job> convertedJobs = jobs.Select(job =>
            {
                return new Job
                {
                    Id = job.Id,
                    CompanyName = job.CompanyName,
                    MinExp = job.MinExp,
                    Salary = job.Salary,
                    Summary = job.Summary,  
                    Vacancy = job.Vacancy,
                    WorkMode = job.WorkMode,
                    ApplicationCount = job.applications.Count,
                };
            }).ToList();
            if (filter.minSalary != null)
            {
                convertedJobs = convertedJobs.Where(j => j.Salary > filter.minSalary).ToList();
            }
            if (filter.maxExperience != null)
            {
                convertedJobs = convertedJobs.Where(j => j.MinExp < filter.maxExperience).ToList();
            }
            if (filter.workMode != null)
            {
                convertedJobs = convertedJobs.Where(j => j.WorkMode.IndexOf(filter.workMode, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            convertedJobs = convertedJobs.OrderByDescending(j => j.Id).ToList();
            return convertedJobs;
        }

        public List<JobApplication> GetJobApplycations(int jobId)
        {
            List<JobApplication> applications;
            using (var db = new UserContext())
            {
                JobDbTable job = db.Jobs.Include(j => j.applications).FirstOrDefault(j => j.Id == jobId);
                applications = job.applications.Select(application =>
                {
                    return new JobApplication
                    {
                        Id = application.Id,
                        message = application.message,
                        userEmail = application.userEmail
                    };
                }).ToList();
            }
            return applications;
        }

        public Job GetJobByIdService(int Id)
        {
            Job job = new Job();
            using (var db = new UserContext())
            {
                JobDbTable dbJob = db.Jobs
                    .Include(j => j.applications)
                    .FirstOrDefault(j => j.Id == Id);

                job.Salary = dbJob.Salary;
                job.Summary = dbJob.Summary;
                job.Vacancy = dbJob.Vacancy;
                job.Id = dbJob.Id;
                job.CompanyName = dbJob.CompanyName;
                job.ApplicationCount = dbJob.applications.Count;
                job.MinExp = dbJob.MinExp;
            }
            return job;
        }

        public SimpleResponse ApplyToJobService(int jobId, string email)
        {
            using (var db = new UserContext())
            {
                UDbTable user = db.Users.Include(u=>u.applications).FirstOrDefault(u => u.Email == email);
                JobDbTable job = db.Jobs.FirstOrDefault(j => j.Id == jobId);
                List<JobApplication> jobApplications = this.GetJobApplycations(jobId);
                bool hasMatchingApplications = user.applications.Any(userApp => jobApplications.Any(jobApp => jobApp.Id == userApp.Id));
                if (hasMatchingApplications) return new SimpleResponse { IsSuccess = false, Msg = "You have already applied for this advertisement" };

                if (user == null) return new SimpleResponse { IsSuccess = false, Msg = "User not found" };
                if (job == null) return new SimpleResponse { IsSuccess = false, Msg = "Job not found" };

                JobApplicationsDbTable newAplication = new JobApplicationsDbTable { message = "Apply to job!", userEmail = user.Email };
                user.applications.Add(newAplication);
                job.applications.Add(newAplication);
                db.SaveChanges();
            }
            return new SimpleResponse { IsSuccess = true, Msg = "Success!" };
        }

        public List<Job> GetUserJobsService(string email)
        {
            List<JobDbTable> jobs;
            using (var db = new UserContext())
            {
                UDbTable user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return null;
                }
                jobs = db.Jobs
                    .Include(j => j.applications)
                    .Where(job => job.OwnerId == user.Id)
                    .ToList();
            }
            List<Job> convertedJobs = (List<Job>)jobs.Select(job =>
            {
                return new Job
                {
                    Id = job.Id,
                    CompanyName = job.CompanyName,
                    MinExp = job.MinExp,
                    Salary = job.Salary,
                    Summary = job.Summary,
                    Vacancy = job.Vacancy,
                    WorkMode = job.WorkMode,
                    ApplicationCount = job.applications.Count
                };
            }).ToList();
            convertedJobs = convertedJobs.OrderByDescending(j => j.Id).ToList();
            return convertedJobs;
        }
    }
}
