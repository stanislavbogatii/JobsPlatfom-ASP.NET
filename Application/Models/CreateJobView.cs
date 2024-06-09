using Application.Models.Job;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class CreateJobView
    {
        public UserData user { get; set; }
        public CreateJobModel jobData { get; set; }
    }
}