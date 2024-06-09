﻿using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Extensions;
using Application.Models.Job;
using System.Collections.Generic;   
using System.Web.Mvc;
using JobFilters = Application.Domain.Entities.Job.JobFilters;

namespace Application.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IJob _job;
        private readonly ISession _session;
        public JobsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _job = bl.GetJobBL();
            _session = bl.GetSessionBL();
        }

        [HttpPost]
        public ActionResult Accept(int jobIdAccept, int userIdAccept, string message)
        {
            SimpleResponse response = _job.SendFeedbackAction(userIdAccept, jobIdAccept, message);
            return RedirectToAction("MyJobs");
        }

        [HttpPost]
        public ActionResult ScheduleInterview(int jobIdInterview, int userIdInterview, string message, string date, string location, string time)
        {
            SimpleResponse response = _job.ScheduleFeedbackAction(userIdInterview, jobIdInterview, date, time, location, message);
            return RedirectToAction("MyJobs");
        }

        public ActionResult JobDetails(int id)
        {
            var job = _job.GetJobByIdAction(id);
            var applications = _job.GetJobApplicationAction(id);

            if (job == null)
            {
                return HttpNotFound();
            }

            var viewModel = new JobDetailsViewModel
            {
                job = job,
                applications = applications
            };

            return View(viewModel);
        }


        public ActionResult Index(Application.Domain.Entities.Job.JobFilters filter)
        {
            List<Job> jobs = _job.GetJobs(filter);
            var viewModel = new JobsListViewModel
            {
                jobs = jobs,
                filter = filter
                
            };
            return View(viewModel);
        }

        public ActionResult MyJobs()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();

            List<Job> jobs = _job.GetUserJobs(session.Email);
            var viewModel = new JobsListViewModel
            {
                jobs = jobs,

            };
            return View(viewModel);
        }

        public ActionResult CV(int id)
        {
            CVDbTable cv = _session.GetCVByUserIdService(id);
            return View(cv);
        }

        [HttpPost]
        public ActionResult Apply(int id, string message)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();

            SimpleResponse response = _job.ApplyToJobAction(id, session.Id, message);

            if (response.IsSuccess == true)
                TempData["SuccessMessage"] = response.Msg;
            else
                TempData["ErrorMessage"] = response.Msg;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(CreateJobModel JobData)
        {
            if (!ModelState.IsValid)
            {
                return View(JobData);
            }
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();

            Job newJob = new Job
            {
                CompanyName = JobData.CompanyName,
                Salary = JobData.Salary,
                MinExp = JobData.MinExp,
                Summary = JobData.Summary,
                Vacancy = JobData.Vacancy,
                WorkMode = JobData.WorkMode
            };

            CreateJobResponse response = _job.CreateJobAction(newJob, session.Email);
            return RedirectToAction("Index", "Jobs");
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}