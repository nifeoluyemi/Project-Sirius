using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAverageReviewConfig : EntityBaseConfig<UserAverageReviewBO>
    {
        public UserAverageReviewConfig()
        {
            Property(u => u.AverageScore).IsOptional();
        }
    }
}
