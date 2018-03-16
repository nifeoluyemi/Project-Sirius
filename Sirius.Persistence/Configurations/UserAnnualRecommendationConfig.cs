using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAnnualRecommendationConfig : EntityBaseConfig<UserAnnualRecommendationBO>
    {
        public UserAnnualRecommendationConfig()
        {
            Property(u => u.UserId).IsRequired();
            Property(u => u.HODId).IsRequired();
            Property(u => u.Year).IsOptional();
        }
    }
}
