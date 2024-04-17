using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            UserRegister u = new UserRegister();
            u.Email = (string)Session["Email"];
            return View(u);
        }

    }
}