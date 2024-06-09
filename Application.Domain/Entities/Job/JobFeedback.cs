using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.Job
{
    public class JobFeedback
    {
        public string userEmail { get; set; }
        public string employerEmail { get; set; }
        public string companyName { get; set; }
        public string vacancyName { get; set; }
        public string message { get; set; }
    }
}
