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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("JobId")]
        public virtual JobDbTable Job { get; set; }

        [ForeignKey("UserId")]
        public virtual UDbTable User { get; set; }

        public DateTime AppliedOn { get; set; }
    }
}
