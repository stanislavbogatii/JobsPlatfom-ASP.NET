using Application.BusinessLogic;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Extensions;
using Application.Models.Job;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly ISession _session;

        public ProfileController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        [HttpPost]
        public ActionResult Edit(EditProfile data, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {

                UpdateUserModel userData = new UpdateUserModel
                {
                    Name = data.Name,
                };

                if (data.photo != null && data.photo.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(data.photo.FileName);
                    var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";

                    var path = Path.Combine(Server.MapPath("~/UploadedFiles"), uniqueFileName);

                    data.photo.SaveAs(path);

                    userData.photoPath = $"/UploadedFiles/{uniqueFileName}";
                }

                SessionStatus();
                var session = System.Web.HttpContext.Current.GetSessionData();

                SimpleResponse response = _session.EditUserAction(userData, session.Email);
                if (response.IsSuccess)
                    return RedirectToAction("Index", "Profile");
                else return View();
            }
            return View();
        }


        public ActionResult Edit()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            UserData userData = new UserData
            {
                Email = session.Email,
                Name = session.Name,
                Cv = session.CV
            };
            return View(userData);
        }
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
                Cv = session.CV,
                photoPath = session.PhotoPath
            };

            return View(userData);
        }
    }
}