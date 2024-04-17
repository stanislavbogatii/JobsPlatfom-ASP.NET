using Application.BusinessLogic.Core;
using Application.BusinessLogic.Interfaces;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class SessionBL : UserApi, ISession
    {
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
