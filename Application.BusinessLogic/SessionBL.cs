using Application.BusinessLogic.Core;
using Application.BusinessLogic.DBModel;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.CV;
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
    public class SessionBL : ISession
    {

        private CVApi cvApi;
        private UserApi userApi;

        public SessionBL()
        {
            this.cvApi = new CVApi();
            this.userApi = new UserApi();
        }

        public CreateCVResponse CVCreateAction(CV data)
        {
            CreateCVResponse CV = cvApi.CreateCVService(data);
            throw new NotImplementedException();
        }

        public HttpCookie GenCookie(string Email)
        {
            return userApi.RGenCookie(Email);
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
