using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities.User;

namespace Application.Domain.Entities.Job
{
    public class JobApplicationsDbTable
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string userEmail { get; set; }

    }
}
