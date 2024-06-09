using Application.BusinessLogic.Core;
using Application.BusinessLogic.DBModel;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.BusinessLogic
{
    public class SessionBL: ISession
    {

        private readonly CVApi cvApi;
        private readonly UserApi userApi;

        public SessionBL()
        {
            this.cvApi = new CVApi();
            this.userApi = new UserApi();
        }

        public SimpleResponse UpdateUserPasswordAction(int id, string newPassword, string prevPassword)
        {
            return userApi.UpdateUserPasswordService(id, newPassword, prevPassword);
        }

        public List<InterviewDbTable> GetEmployeeInterviewService(int id)
        {
            return userApi.GetEmployeeInterviewService(id);
        }
        public List<JobFeedbackDbTable> GetEmployeeFeedbackService(int id)
        {
            return userApi.GetEmployeeFeedbackService(id);
        }

        public CreateCVResponse CVEditAction(CV data, int cvId)
        {
            return cvApi.EditCVService(data, cvId);
        }

        public SimpleResponse EditUserAction(UpdateUserModel data, string email)
        {
            return userApi.RUpdateUser(data, email);
        }

        public CreateCVResponse CVCreateAction(CV data, string userEmail)
        {
            return cvApi.CreateCVService(data, userEmail);
        }

        public HttpCookie GenCookie(string Email)
        {
            return userApi.RGenCookie(Email);
        }

        public CVDbTable GetCVByUserIdService(int userId)
        {
            return userApi.GetCVByUserIdService(userId);
        }

        public User GetUserByCookie(string CookieValue)
        {
            return userApi.RGetUserByCookie(CookieValue);
        }

        public URegisterResponse UserRegistrationAction(URegisterData data)
        {
            return userApi.RRegisterService(data);
        }

        ULoginResponse ISession.UserLoginAction(ULoginData data)
        {
            return userApi.RLoginService(data);
        }
    }
}
