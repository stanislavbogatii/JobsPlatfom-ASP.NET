﻿using Application.BusinessLogic.DBModel;
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

            //var pass = LoginHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
            }
            if (user != null) return new ULoginResponse { IsSuccess = true };

            return new ULoginResponse { IsSuccess = false };
        }

        public URegisterResponse RRegisterService(URegisterData data)
        {
            // var pass = LoginHelper.HashGen(data.Password);

            var newUser = new UDbTable
            {
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                LastIp = data.LoginIp,
                LastLogin = DateTime.Now,
                Role = URole.User
            };

            using (var db = new UserContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return new URegisterResponse { IsSuccess = true }; ;
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
                curentUser = db.Users.FirstOrDefault(u => u.Email == session.Email);
            }
            if (curentUser == null) return null;


            var user = new User
            {
                Email = curentUser.Email,
                Name = curentUser.Name,
                Role = curentUser.Role
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
