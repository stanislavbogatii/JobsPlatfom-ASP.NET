using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities.Job
{
    public class JobFilters
    {
        public string workMode { get; set; }
        public int? minSalary { get; set; }
        public int? maxExperience { get; set; }
    }
}
