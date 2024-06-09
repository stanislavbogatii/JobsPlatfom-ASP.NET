using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Extensions;
using Application.Domain.Entities.User;
using Application.Models;

namespace Application.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();

            UserData userData;
            if (session == null)
            {
                userData = null;
            }
            else
            {
                userData = new UserData
                {
                    Name = session.Name,
                    Email = session.Email,
                    Role = session.Role
                };
            }


            var viewData = new HomeView
            {
                user = userData
            };

            return View(viewData);
        }
    }
}