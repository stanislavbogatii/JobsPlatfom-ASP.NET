using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Extensions
{
    public static class HttpContextExtensions
    {
        public static User GetSessionData(this HttpContext current)
        {
            return (User)current?.Session["__SessionData"];
        }

        public static void SetSessionData(this HttpContext current, User user)
        {
            current.Session.Add("__SessionData", user);
        }
    }
}