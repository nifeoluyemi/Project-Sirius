using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class AppraisalRecommendationConfig : EntityBaseConfig<AppraisalRecommendationBO>
    {
        public AppraisalRecommendationConfig()
        {
            Property(a => a.Recommendation).IsRequired().HasMaxLength(250);
            Property(a => a.Description).IsOptional().HasMaxLength(500);
        }
    }
}
