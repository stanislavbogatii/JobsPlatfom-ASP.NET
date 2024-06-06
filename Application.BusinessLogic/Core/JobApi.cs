﻿using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public List<Job> GetJobsService()
        {
            List<JobDbTable> jobs;
            using (var db = new UserContext())
            {
                jobs = db.Jobs.ToList();
            }
            List<Job> convertedJobs = jobs.Select(job =>
            {
                return new Job
                {
                    CompanyName = job.CompanyName,
                    MinExp = job.MinExp,
                    Salary = job.Salary,
                    Summary = job.Summary,
                    Vacancy = job.Vacancy,
                    WorkMode = (JobModType)Enum.Parse(typeof(JobModType), job.WorkMode)
                };
            }).ToList();
            return convertedJobs;
        }

        public SimpleResponse ApplyToJob(int jobId, string email)
        {
            return new SimpleResponse { IsSuccess = true };
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
                    WorkMode = (JobModType)Enum.Parse(typeof(JobModType), job.WorkMode)
                };
            });
            return convertedJobs;
        }
    }
}