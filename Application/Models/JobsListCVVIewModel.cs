using Application.Domain.Entities.CV;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class JobsListCVVIewModel
    {
        public CVDbTable cv { get; set; }
        public UserData user { get; set; }
    }
}