using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.Job
{
    public class Interview
    {
        public string date { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public string userEmail { get; set; }
        public string employerEmail { get; set; }
        public string companyName { get; set; }
        public string vacancyName { get; set; }
        public string message { get; set; }
    }
}
