using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Response;
using Application.Extensions;
using Application.Models;
using Application.Models.cv;
using Application.Models.User;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education = Application.Domain.Entities.CV.Education;
using Experience = Application.Domain.Entities.CV.Experience;

namespace Application.Controllers
{
    public class CVController : BaseController
    {

        private readonly ISession _session;

        public CVController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult Index()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            ProfileViewModels viewData = new ProfileViewModels
            {
                user = new UserData
                {
                    Role = session.Role
                }
            };
            return View(viewData);
        }
        
        public ActionResult Create()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            ProfileViewModels viewData = new ProfileViewModels
            {
                user = new UserData
                {
                    Role = session.Role
                }
            };
            return View(viewData);
        }

        public ActionResult Edit()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserData userData = new UserData
            {
                Cv = session.CV,
                Role = session.Role
            };
            ProfileViewModels viewModel = new ProfileViewModels
            {
                user = userData
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateCVModel CVData)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            Experience[] experiences = new Experience[CVData.ExperienceDurations.Length];
            for (int i = 0; i < experiences.Length; i++)
            {
                experiences[i] = new Experience() { Name = CVData.ExperienceNames[i], Duration = (int)CVData.ExperienceDurations[i] };
            }

            Education[] educations = new Education[CVData.EducationDurations.Length];
            for (int i = 0; i < CVData.EducationDurations.Length; i++)
            {
                educations[i] = new Education() { Name = CVData.EducationNames[i], Duration = (int)CVData.EducationDurations[i] };
            }

            Skill[] skills = new Skill[CVData.Skills.Length];
            for (int i = 0; i < CVData.Skills.Length; i++)
            {
                skills[i] = new Skill() { Name = CVData.Skills[i] };
            }

            CV newCv = new CV
            {
                Skills = skills,
                Experiences = experiences,
                Summary = CVData.Summary,
                Educations = educations,
            };

            CreateCVResponse response = _session.CVCreateAction(newCv, session.Email);
            if (response.IsSuccess)
            {
                return RedirectToAction("Index", "Profile");
            } 
            else
            {
                ViewBag.ErrorMessage = response.Msg;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(EditCVModel CVData)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();

            Experience[] experiences = new Experience[CVData.ExperienceDurations.Length];
            for (int i = 0; i < experiences.Length; i++)
            {
                if (!string.IsNullOrEmpty(CVData.ExperienceNames[i]))
                {
                    experiences[i] = new Experience() { Name = CVData.ExperienceNames[i], Duration = (int)CVData.ExperienceDurations[i] };
                }
            }

            Education[] educations = new Education[CVData.EducationDurations.Length];
            for (int i = 0; i < CVData.EducationDurations.Length; i++)
            {
                if (!string.IsNullOrEmpty(CVData.EducationNames[i]))
                {
                    educations[i] = new Education() { Name = CVData.EducationNames[i], Duration = (int)CVData.EducationDurations[i] };
                }
            }

            Skill[] skills = new Skill[CVData.Skills.Length];
            for (int i = 0; i < CVData.Skills.Length; i++)
            {
                if (!string.IsNullOrEmpty(CVData.Skills[i]))
                {
                    skills[i] = new Skill() { Name = CVData.Skills[i] };
                }
            }

            CV updatedCv = new CV
            {
                Skills = skills,
                Experiences = experiences,
                Summary = CVData.Summary,
                Educations = educations,
            };

            CreateCVResponse response = _session.CVEditAction(updatedCv, session.CV.Id);
            if (response.IsSuccess)
            {
                return RedirectToAction("Index", "Profile");
            }
            else
            {
                ViewBag.ErrorMessage = response.Msg;
                return View();
            }
        }
    }
}