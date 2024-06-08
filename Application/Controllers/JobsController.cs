using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Extensions;
using Application.Models.Job;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class JobsController : BaseController
    {
        private readonly IJob _job;
        public JobsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _job = bl.GetJobBL();
        }
        public ActionResult Index()
        {
            List<Job> jobs = _job.GetJobs();
            var viewModel = new JobsListViewModel
            {
                jobs = jobs
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Apply(int id)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            SimpleResponse response = _job.ApplyToJobAction(id, session.Email);

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