using Application.BusinessLogic;
using Application.BusinessLogic.Interfaces;
using Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Application.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        private readonly ISession _session;

        public BaseController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            HttpCookie cookie = ControllerContext.HttpContext.Request.Cookies.Get("X-KEY");
            Response.Cookies["X-KEY"].Expires = DateTime.Now.AddDays(-1);
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        public void SessionStatus()
        {
            var cookie = Request.Cookies["X-KEY"];
            if (cookie == null)
            {
                System.Web.HttpContext.Current.Session.Clear();
                return;
            }

            var user = _session.GetUserByCookie(cookie.Value);
            if (user != null)
            {
                System.Web.HttpContext.Current.SetSessionData(user);
                System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }

        }
    }
}