using Application.Extensions;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserData userData = new UserData { 
                Email = session.Email, 
                Name = session.Name,
                Cv = session.CV
            };

            return View(userData);
        }
    }
}