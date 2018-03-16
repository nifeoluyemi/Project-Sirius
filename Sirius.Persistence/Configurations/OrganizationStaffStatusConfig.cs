using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class OrganizationStaffStatusConfig : EntityBaseConfig<OrganizationStaffStatusBO>
    {
        public OrganizationStaffStatusConfig()
        {
            Property(o => o.StatusName).IsOptional().HasMaxLength(200);
            Property(o => o.StatusName).IsRequired().HasMaxLength(50);

            HasMany(o => o.Users).WithRequired(u => u.OrganizationStaffStatus).HasForeignKey(u => u.OrganizationStaffStatusId);
        }
    }
}
