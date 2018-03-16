using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserDimensionEvaluationConfig : EntityBaseConfig<UserDimensionEvaluationBO>
    {
        public UserDimensionEvaluationConfig()
        {
            Property(u => u.Rating).IsOptional();
        }
    }
}
