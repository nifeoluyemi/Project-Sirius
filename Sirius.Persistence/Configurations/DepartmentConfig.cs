using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class DepartmentConfig : EntityBaseConfig<DepartmentBO>
    {
        public DepartmentConfig()
        {
            Property(d => d.Name).IsRequired().HasMaxLength(250);
            Property(d => d.ShortName).IsRequired().HasMaxLength(40);
            Property(d => d.Description).IsOptional().IsMaxLength();

            //HasMany(d => d.Users).WithRequired(u => u.Department).HasForeignKey(u => u.DepartmentId);
        }
    }
}
