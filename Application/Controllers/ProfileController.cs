using Application.BusinessLogic;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Extensions;
using Application.Models;
using Application.Models.Job;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
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
            return Edit();
        }

        public ActionResult Interviews()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            List<InterviewDbTable> interviews =_session.GetEmployeeInterviewService(session.Id);
            ProfileInterviewsView viewModel = new ProfileInterviewsView
            {
                interviews = interviews,
                user = new UserData
                {
                    Role = session.Role
                }
            };
            return View(viewModel);
        }

        public ActionResult Feedback()
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            List<JobFeedbackDbTable> feedback = _session.GetEmployeeFeedbackService(session.Id);
            ProfileFeedbackView viewModel = new ProfileFeedbackView
            {
                feedback = feedback,
                user = new UserData
                {
                    Role = session.Role
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdatePassword(string newPassword, string prevPassword)
        {
            SessionStatus();
            var session = System.Web.HttpContext.Current.GetSessionData();
            SimpleResponse response = _session.UpdateUserPasswordAction(session.Id, newPassword, prevPassword);
            if (response.IsSuccess == true)
                TempData["SuccessMessage"] = response.Msg;
            else
                TempData["ErrorMessage"] = response.Msg;
            return RedirectToAction("Index", "Profile");
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
            ProfileViewModels viewData = new ProfileViewModels
            {
                user = userData
            };
            return View(viewData);
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
                photoPath = session.PhotoPath,
                Role = session.Role
            };
            ProfileViewModels viewData = new ProfileViewModels
            {
                user = userData
            };

            return View(viewData);
        }
    }
}