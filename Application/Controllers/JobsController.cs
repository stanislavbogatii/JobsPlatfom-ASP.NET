using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Extensions;
using Application.Models;
using Application.Models.Job;
using Application.Models.User;
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
        public ActionResult Accept(int jobIdAccept, int userIdAccept)
        {
            SimpleResponse response = _job.SendFeedbackAction(userIdAccept, jobIdAccept);
            if (response.IsSuccess == true)
                TempData["SuccessMessage"] = response.Msg;
            else
                TempData["ErrorMessage"] = response.Msg;
            return RedirectToAction("MyJobs");
        }

        [HttpPost]
        public ActionResult ScheduleInterview(int jobIdInterview, int userIdInterview, string date, string location, string time)
        {
            SimpleResponse response = _job.ScheduleFeedbackAction(userIdInterview, jobIdInterview, date, time, location);
            if (response.IsSuccess == true)
                TempData["SuccessMessage"] = response.Msg;
            else
                TempData["ErrorMessage"] = response.Msg;
            return RedirectToAction("MyJobs");
        }

        public ActionResult JobDetails(int id)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            var job = _job.GetJobByIdAction(id);
            var applications = _job.GetJobApplicationAction(id);

            if (job == null)
            {
                return HttpNotFound();
            }

            var viewModel = new JobDetailsViewModel
            {
                job = job,
                user = new Models.User.UserData
                {
                    Role = session.Role
                },
                applications = applications
            };

            return View(viewModel);
        }


        public ActionResult Index(Application.Domain.Entities.Job.JobFilters filter)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            List<Job> jobs = _job.GetJobs(filter);
            var viewModel = new JobsListViewModel
            {
                jobs = jobs,
                filter = filter,
                user = new UserData
                {
                    Role = session.Role
                }
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
                user = new UserData
                {
                    Role = session.Role
                }

            };
            return View(viewModel);
        }

        public ActionResult CV(int id)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            CVDbTable cv = _session.GetCVByUserIdService(id);
            var viewModel = new JobsListCVVIewModel
            {
                user = new UserData
                {
                    Role = session.Role,
                },
                cv = cv
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Apply(int id, string message)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            if (session.CV == null)
            {
                TempData["ErrorMessage"] = "Before submitting your application, create your CV";
                return RedirectToAction("Create", "CV");
            }
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
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            CreateJobView viewModel = new CreateJobView
            {
                jobData = JobData,
                user = new UserData
                {
                    Role = session.Role
                }
            };
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            

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
            if (response.IsSuccess == true)
                TempData["SuccessMessage"] = response.Msg;
            else
                TempData["ErrorMessage"] = response.Msg;
            return RedirectToAction("Index", "Jobs");
        }

        public ActionResult Create()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            CreateJobView viewModel = new CreateJobView
            {
                user = new UserData
                {
                    Role = session.Role
                }
            };
            return View(viewModel);
        }
    }
}