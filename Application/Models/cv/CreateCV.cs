using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Application.Models.cv
{
    public class CreateCVModel
    {
        [Display(Name = "Skills")]
        public string[] Skills { get; set; }

        [Display(Name = "ExperienceNames")]
        public string[] ExperienceNames { get; set; }

        [Display(Name = "ExperienceDurations")]
        public int[] ExperienceDurations { get; set; }

        [Display(Name = "EducationNames")]
        public string[] EducationNames { get; set; }

        [Display(Name = "EducationDurations")]
        public int[] EducationDurations { get; set; }

        [Display(Name = "Summary")]
        public string Summary { get; set; }
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


