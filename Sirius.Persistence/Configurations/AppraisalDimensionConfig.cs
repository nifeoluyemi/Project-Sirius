using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class AppraisalDimensionConfig : EntityBaseConfig<AppraisalDimensionBO>
    {
        public AppraisalDimensionConfig()
        {
            Property(ad => ad.DimensionName).IsRequired().HasMaxLength(200);
            Property(ad => ad.Description).IsOptional().HasMaxLength(1000);
            Property(ad => ad.MaxScore).IsRequired();
        }
    }
}
