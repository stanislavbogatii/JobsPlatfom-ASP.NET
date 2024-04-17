using Application.BusinessLogic.Core;
using Application.BusinessLogic.DBModel;
using Application.BusinessLogic.Interfaces;
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
    public class SessionBL : UserApi, ISession
    {
        public HttpCookie GenCookie(string Email)
        {
            return RGenCookie(Email);
        }

        public User GetUserByCookie(string CookieValue)
        {
            return RGetUserByCookie(CookieValue);
        }

        public URegisterResponse UserRegistrationAction(URegisterData data)
        {
            return RRegisterService(data);
        }

        ULoginResponse ISession.UserLoginAction(ULoginData data)
        {
            return RLoginService(data);
        }
    }
}
