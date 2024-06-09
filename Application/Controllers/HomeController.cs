using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Extensions;
using Application.Domain.Entities.User;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserData userData = new UserData();
            userData.Name = session.Name;
            userData.Email = session.Email;
            userData.Role = session.Role;

            return View(userData);
        }
    }
}