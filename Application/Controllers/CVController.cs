using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class CVController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        
        
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string[] experiences, string[] skills)
        {
            return View();
        }






        public ActionResult Edit()
        {
            return View();
        }
    }
}