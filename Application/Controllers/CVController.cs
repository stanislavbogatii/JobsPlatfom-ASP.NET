using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Response;
using Application.Extensions;
using Application.Models.cv;
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
            return View();
        }
        
        public ActionResult Create()
        {
            return View();
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
            for (int i = 0; i < experiences.Length; i++)
            {
                educations[i] = new Education() { Name = CVData.EducationNames[i], Duration = (int)CVData.EducationDurations[i] };
            }

            Skill[] skills = new Skill[CVData.Skills.Length];
            for (int i = 0; i < skills.Length; i++)
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

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}