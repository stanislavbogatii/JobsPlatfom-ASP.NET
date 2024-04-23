using Application.Domain.Entities.CV;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;



namespace Application.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=Solution")
        {
        }
        public virtual DbSet<UDbTable> Users { get; set; }
        public virtual DbSet<CVDbTable> CVs { get; set; }

    }
}
