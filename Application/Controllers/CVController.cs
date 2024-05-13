using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Response;
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
    public class CVController : Controller
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
            Experience[] experiences = new Experience[]
            {
                new Experience("Software Developer", 2),
                new Experience("Web Developer", 3),
                new Experience("Database Administrator", 1)
                // Добавьте другие объекты Experience по необходимости
            };

            Education[] educations = new Education[]
            {
                new Education("Software Developer", 2),
                new Education("Web Developer", 3),
                new Education("Database Administrator", 1)
                // Добавьте другие объекты Experience по необходимости
            };

            CV newCv = new CV
            {
                Skills = CVData.Skills,
                Experiences = experiences,
                Summary = CVData.Summary,
                Educations = educations,
            };

            CreateCVResponse response = _session.CVCreateAction(newCv);
            return View();
        }






        public ActionResult Edit()
        {
            return View();
        }
    }
}