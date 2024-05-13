using Application.Domain.Entities.CV;
using Application.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.DBModel
{
    public class UserDbConfiguration : EntityTypeConfiguration<UDbTable>
    {

    public UserDbConfiguration()
        {
            this.HasOptional<CVDbTable>(x => x.CV);
            this.HasOptional(x => x.CV);
        }
    }
}
