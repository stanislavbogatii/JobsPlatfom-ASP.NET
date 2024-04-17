using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=Solution")
        {
        }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}
