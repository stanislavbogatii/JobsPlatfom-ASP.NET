using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.Session["__SessionData"];
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserRegister u = new UserRegister();
            u.Email = (string)Session["Email"];
            return View(u);
        }
    }
}