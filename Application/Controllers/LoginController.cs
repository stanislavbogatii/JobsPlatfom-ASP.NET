using Application.BusinessLogic;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;
        
        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(UserLogin loginData) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ULoginData data = new ULoginData
            {
                Email = loginData.Email,
                Password = loginData.Password,
                LoginIp = Request.UserHostAddress,
                LoginDateTime = DateTime.Now
            };

            ULoginResponse response = _session.UserLoginAction(data);
            if (response.IsSuccess)
            {
                Session["Email"] = data.Email;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}