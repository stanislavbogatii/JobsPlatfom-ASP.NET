﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.User
{
    public class UserRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsEmployer { get; set; }
    }
}