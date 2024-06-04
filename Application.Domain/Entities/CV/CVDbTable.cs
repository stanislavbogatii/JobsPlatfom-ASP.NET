using Application.Domain.Entities.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Domain.Entities.CV
{
    public class CVDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }


        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }

    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Skill Name")]
        public string Name { get; set; }
    }

    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Experience Name")]
        public string Name { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }
    }

    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Education Name")]
        public string Name { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }
    }
}