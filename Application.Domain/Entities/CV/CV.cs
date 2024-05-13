using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.Domain.Entities.User;
using System;

namespace Application.Domain.Entities.CV
{
    public class CV
    {

        public string[] Skills { get; set; }

        public Experience[] Experiences { get; set; }

        public string Summary { get; set; }

        public Education[] Educations { get; set; }

    }
}


