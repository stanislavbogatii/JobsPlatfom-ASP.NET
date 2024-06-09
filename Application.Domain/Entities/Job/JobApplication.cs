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
        public int Id { get; set; }

        public string message { get; set; }
    }
}
