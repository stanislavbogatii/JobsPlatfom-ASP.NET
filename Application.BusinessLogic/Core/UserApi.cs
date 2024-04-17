using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.Response;
using Application.Domain.Entities.User;
using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Core
{
    public class UserApi
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
    }
}
