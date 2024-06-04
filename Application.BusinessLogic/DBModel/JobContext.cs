/*using Application.Domain.Entities.Job;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.DBModel
{
    public class JobContext : DbContext
    {
        public JobContext() :
            base("name=Solution")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobDbTable>()
               .HasRequired(j => j.Owner)
               .WithMany()
               .HasForeignKey(j => j.OwnerId)
               .WillCascadeOnDelete(false);

            // Configure the JobApplicationsDbTable entity
            modelBuilder.Entity<JobApplicationsDbTable>()
                .HasRequired(ja => ja.Job)
                .WithMany(j => (ICollection<JobApplicationsDbTable>)j.JobApplications)
                .HasForeignKey(ja => ja.JobId);

            modelBuilder.Entity<JobApplicationsDbTable>()
                .HasRequired(ja => ja.User)
                .WithMany()
                .HasForeignKey(ja => ja.UserId);
        }
    }
}
*/