using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class OrganizationConfig : EntityBaseConfig<OrganizationBO>
    {
        public OrganizationConfig()
        {
            Property(o => o.Name).IsRequired().HasMaxLength(250);
            Property(o => o.ShortName).IsRequired().HasMaxLength(30);

            Property(o => o.OrganizationLogo).IsOptional();
            Property(o => o.ImageMimeType).IsOptional().HasMaxLength(10);

            HasMany(o => o.Users).WithRequired(u => u.Organization).HasForeignKey(u => u.OrganizationId).WillCascadeOnDelete(false);
           
            HasMany(o => o.PrivilegeRequests).WithRequired(p => p.Organization).HasForeignKey(p => p.OrganizationId).WillCascadeOnDelete(false);
        }
    }
}
