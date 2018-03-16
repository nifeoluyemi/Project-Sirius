using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class OrganizationConfig : EntityBaseConfig<OrganizationBO>
    {
        public OrganizationConfig()
        {
            Property(o => o.Name).IsRequired().HasMaxLength(250);
            Property(o => o.ShortName).IsRequired().HasMaxLength(30);
            Property(o => o.EmailSuffix).IsOptional().HasMaxLength(200);
            Property(o => o.DomainName).IsOptional().HasMaxLength(300);

            Property(o => o.MissionStatement).IsOptional().IsMaxLength();
            Property(o => o.VisionStatement).IsOptional().IsMaxLength();

            Property(o => o.OrganizationLogo).IsOptional();
            Property(o => o.ImageMimeType).IsOptional().HasMaxLength(10);

            HasMany(o => o.Users).WithOptional(u => u.Organization).HasForeignKey(u => u.OrganizationId);
            HasMany(o => o.Departments).WithRequired(d => d.Organization).HasForeignKey(d => d.OrganizationId);
            HasMany(o => o.AppraisalPeriods).WithRequired(a => a.Organization).HasForeignKey(a => a.OrganizationId);
            HasMany(o => o.AppraisalDimensions).WithRequired(a => a.Organization).HasForeignKey(a => a.OrganizationId);
            HasMany(o => o.OrganizationStaffStatus).WithRequired(o => o.Organization).HasForeignKey(o => o.OrganizationId);
            HasMany(o => o.AppraisalRecommendations).WithRequired(u => u.Organization).HasForeignKey(u => u.OrganizationId);
            HasMany(o => o.OrganizationObjectives).WithRequired(o => o.Organization).HasForeignKey(o => o.OrganizationId);
        }
    }
}
