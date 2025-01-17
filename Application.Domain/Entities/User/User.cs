﻿using Application.Domain.Entities.CV;
using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string LoginIp { get; set; }
        public string Role { get; set; }
        public CVDbTable CV { get; set; }
        public string PhotoPath { get; set; }
    }
}
