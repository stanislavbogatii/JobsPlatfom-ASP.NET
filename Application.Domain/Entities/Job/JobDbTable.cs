using Application.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Application.Domain.Entities.User;

namespace Application.Domain.Entities.Job
{
    [Table("Jobs")]
    public class JobDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Vacancy { get; set; }

        [Required]
        [Column("WorkMode")]
        public string WorkMode { get; set; }

        public string Summary { get; set; }

        public int MinExp { get; set; }

        public int Salary { get; set; }

        public int OwnerId { get; set; }

        public virtual UDbTable Owner { get; set; }

        public virtual ICollection<UDbTable> InterestedUsers { get; set; }
        public virtual ICollection<JobApplicationsDbTable> applications { get; set; }
    }
}
