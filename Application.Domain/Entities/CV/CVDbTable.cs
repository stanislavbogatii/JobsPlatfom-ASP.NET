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
        public string[] Skills { get; set; }

        [Display(Name = "Experiences")]
        public Experience[] Experiences { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Display(Name = "Educations")]
        public Education[] Educations { get; set; }
     
    }

    public class Experience
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

    public class Education
    {
        public string Name { get; set; }
        public int Duration { get; set; }
    }

}


