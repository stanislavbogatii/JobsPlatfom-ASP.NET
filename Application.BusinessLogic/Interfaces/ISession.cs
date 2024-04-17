using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Interfaces
{
    public interface ISession   
    {
        ULoginResponse UserLoginAction(ULoginData data);
        URegisterResponse UserRegistrationAction(URegisterData data);
    }
}
