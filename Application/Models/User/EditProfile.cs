using Application.Domain.Entities.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.User
{
    public class EditProfile
    {
        public string Name { get; set; }
        public HttpPostedFileBase photo { get; set; }
    }
}