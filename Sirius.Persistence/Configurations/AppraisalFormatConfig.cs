using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class AppraisalFormatConfig : EntityBaseConfig<AppraisalFormatBO>
    {
        public AppraisalFormatConfig()
        {
            Property(a => a.Description).IsOptional().IsMaxLength();
            Property(a => a.OrganizationId).IsRequired();
        }
    }
}
