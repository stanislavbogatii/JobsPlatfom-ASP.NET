using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.CV;
using Application.Domain.Entities.Job;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Domain.Enum;
using Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.BusinessLogic.Core
{
    public class UserApi : SessionApi
    {
        public ULoginResponse RLoginService(ULoginData data)
        {
            UDbTable user;

            var pass = HashGenerator.GenerateHash(data.Password);
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
            }
            if (user != null) return new ULoginResponse { IsSuccess = true };

            return new ULoginResponse { IsSuccess = false, Msg = "Email or Password is not correct" };
        }

        public URegisterResponse RRegisterService(URegisterData data)
        {
            UDbTable user;
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Email);
            }
            if (user != null)
            {
                return new URegisterResponse { IsSuccess = false, Msg = "User with same email already exist" };
            }

            var pass = HashGenerator.GenerateHash(data.Password);

            var newUser = new UDbTable
            {
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                LastIp = data.LoginIp,
                LastLogin = DateTime.Now,
                Role = data.role
            };

            using (var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return new URegisterResponse { IsSuccess = true }; ;
        }

        public SimpleResponse RUpdateUser(UpdateUserModel data, string email)
        {
            UDbTable user;
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    return new SimpleResponse { IsSuccess = false, Msg = "Usser not found" };
                }

                user.Name = data.Name;
                user.PhotoPath = data.photoPath;

                db.SaveChanges();

            }
            return new SimpleResponse { IsSuccess = true }; ;
        }

        public User RGetUserByCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                curentUser = db.Users
                    .Include(u => u.CV)
                    .Include(u => u.CV.Educations)
                    .Include(u => u.CV.Skills)
                    .Include(u => u.CV.Experiences)
                    .FirstOrDefault(u => u.Email == session.Email);
                
            }
            if (curentUser == null) return null;

            var user = new User
            {
                Email = curentUser.Email,
                Name = curentUser.Name,
                Role = curentUser.Role,
                CV = curentUser.CV,
                PhotoPath = curentUser.PhotoPath
            };

            return user;
        }

        public HttpCookie RGenCookie(string Email)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Generate(Email)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(Email))
                {
                    curent = (from e in db.Sessions where e.Email == Email select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Email == Email select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Email = Email,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }
    }
}
