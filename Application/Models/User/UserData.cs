using Application.Domain.Entities.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.User
{
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CVDbTable Cv { get; set; }
        public string photoPath { get; set; }
    }
}