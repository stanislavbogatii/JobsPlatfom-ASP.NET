using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Core
{
    public class CVApi
    {
        public CreateCVResponse CreateCVService(CV data)
        {
            return new CreateCVResponse { IsSuccess = false, Msg = "Email or Password is not correct" };
        }
    }
}
