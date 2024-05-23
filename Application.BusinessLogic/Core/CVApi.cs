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
using System.Data.Entity;

namespace Application.BusinessLogic.Core
{
    public class CVApi
    {
        public CreateCVResponse EditCVService(CV data, int cvId)
        {
            using (var db = new UserContext())
            {
                CVDbTable CV = db.CVs
                           .Include(c => c.Skills)
                           .Include(c => c.Experiences)
                           .Include(c => c.Educations)
                           .FirstOrDefault(c => c.Id == cvId);

                if (CV != null)
                {
                    CV.Skills.Clear();
                    CV.Experiences.Clear();
                    CV.Educations.Clear();

                    foreach (var skill in data.Skills)
                    {
                        CV.Skills.Add(skill);
                    }
                    foreach (var education in data.Educations)
                    {
                        CV.Educations.Add(education);
                    }
                    foreach (var experience in data.Experiences)
                    {
                        CV.Experiences.Add(experience);
                    }


                    db.SaveChanges();
                    return new CreateCVResponse { IsSuccess = true, Msg = "Success edit a CV" };
                }
            }

            return new CreateCVResponse { IsSuccess = false, Msg = "Failed edit a CV" };
        }
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
