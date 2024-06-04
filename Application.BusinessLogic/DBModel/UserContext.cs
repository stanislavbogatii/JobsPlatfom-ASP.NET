using Application.Domain.Entities.CV;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Application.BusinessLogic.DBModel;
using Application.Domain.Entities.Job;

namespace Application.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=Solution")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserDbConfiguration());
        }

        public virtual DbSet<UDbTable> Users { get; set; }
        public virtual DbSet<CVDbTable> CVs { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<JobDbTable> Jobs { get; set; }


    }
}
