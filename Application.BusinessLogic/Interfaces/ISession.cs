﻿using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.BusinessLogic.Interfaces
{
    public interface ISession   
    {
        ULoginResponse UserLoginAction(ULoginData data);
        URegisterResponse UserRegistrationAction(URegisterData data);
        HttpCookie GenCookie(string Email);
        User GetUserByCookie(string CookieValue);
        CVDbTable GetCVByUserIdService(int userId);
        CreateCVResponse CVCreateAction(CV data, string userEmail);
        SimpleResponse EditUserAction(UpdateUserModel data, string email);
        List<InterviewDbTable> GetEmployeeInterviewService(int id);
        List<JobFeedbackDbTable> GetEmployeeFeedbackService(int id);
        SimpleResponse UpdateUserPasswordAction(int id, string newPassword, string prevPassword);
        CreateCVResponse CVEditAction(CV data, int cvId);
    }
}
