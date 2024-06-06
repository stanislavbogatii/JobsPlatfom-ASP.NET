using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.Job
{
    public class JobApplication
    {
        public int JobApplicationId { get; set; }

        [ForeignKey("UDbTable")]
        public int UserId { get; set; }
        public UDbTable User { get; set; }

        [ForeignKey("JobDbTable")]
        public int JobId { get; set; }
        public JobDbTable Job { get; set; }

        public DateTime ApplicationDate { get; set; }
    }
}
