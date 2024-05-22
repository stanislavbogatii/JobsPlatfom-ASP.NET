using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Domain.Enum;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Core
{
    public class CVApi
    {
        public CreateCVResponse CreateCVService(CV data, string userEmail)
        {
            CVDbTable newCv = new CVDbTable
            {
                Educations = data.Educations,
                Experiences = data.Experiences,
                Skills = data.Skills,
                Summary = data.Summary,
                
            };
            using (var db = new UserContext())
            {
                UDbTable user = db.Users.FirstOrDefault(u => u.Email == userEmail);
                if (user != null)
                {
                    user.CV = newCv;
                    db.SaveChanges();
                    return new CreateCVResponse { IsSuccess = true, Msg = "Success create a CV" };
                }
            }

            return new CreateCVResponse { IsSuccess = false, Msg = "Failed create a CV" };
        }

      
    }
}
