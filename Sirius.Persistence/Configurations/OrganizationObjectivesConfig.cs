using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class OrganizationObjectivesConfig : EntityBaseConfig<OrganizationObjectiveBO>
    {
        public OrganizationObjectivesConfig()
        {
            Property(o => o.Objective).IsRequired().HasMaxLength(350);
            Property(o => o.Description).IsOptional().IsMaxLength();
            Property(o => o.Year).IsOptional();
        }
    }
}
