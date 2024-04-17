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
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegister registerData)
        {
            URegisterData data = new URegisterData
            {
                Email = registerData.Email,
                Name = registerData.Name,
                Password = registerData.Password,
                LoginDateTime = DateTime.Now,
                LoginIp = Request.UserHostAddress
            };

            URegisterResponse response = _session.UserRegistrationAction(data);
            if (response.IsSuccess)
            {
                HttpCookie cookie = _session.GenCookie(data.Email);
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }


            return View();
        }
    }
}