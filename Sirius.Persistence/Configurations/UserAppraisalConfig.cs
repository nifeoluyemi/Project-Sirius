using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAppraisalConfig : EntityBaseConfig<UserAppraisalBO>
    {
        public UserAppraisalConfig()
        {
            Property(u => u.AverageRating).IsOptional();
        }
    }
}
