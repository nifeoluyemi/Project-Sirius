using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserConfig : EntityBaseConfig<UserBO>
    {
        public UserConfig()
        {
            Property(u => u.StaffUserName).IsRequired().HasMaxLength(100);
            Property(u => u.FirstName).IsOptional().HasMaxLength(100);
            Property(u => u.MiddleName).IsOptional().HasMaxLength(100);
            Property(u => u.LastName).IsOptional().HasMaxLength(100);
            Property(u => u.DateOfBirth).IsOptional();
            Property(u => u.StaffId).IsOptional().HasMaxLength(100);
            Property(u => u.DepartmentId).IsOptional();

            Property(u => u.ImageContent).IsOptional();
            Property(u => u.ImageMimeType).IsOptional();

            Property(u => u.DepartmentId).IsOptional();
            Property(u => u.OrganizationId).IsOptional();

            HasMany(u => u.Statuses).WithRequired(u => u.User).HasForeignKey(u => u.UserId);
        }
    }
}
