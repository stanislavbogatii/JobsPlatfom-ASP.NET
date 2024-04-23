using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.Domain.Entities.User;

namespace Application.Domain.Entities.CV
{
    public class CVDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Skills")]
        public string Skills { get; set; }

        [Display(Name = "Experiences")]
        public string Experience { get; set; }

        [Display(Name = "Additional")]
        public string Additional { get; set; }

        [Display(Name = "Educations")]
        public string Educations { get; set; }

        public int UserId { get; set; }
    }
}


