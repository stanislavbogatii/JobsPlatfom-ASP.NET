using Application.Domain.Entities.Job;
using Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class ProfileInterviewsView
    {
        public List<InterviewDbTable> interviews { get; set; }
        public UserData user { get; set; }
    }
}