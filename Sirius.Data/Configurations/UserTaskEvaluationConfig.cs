using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class UserTaskEvaluationConfig : EntityBaseConfig<UserTaskEvaluationBO>
    {
        public UserTaskEvaluationConfig()
        {
            Property(u => u.UserTaskId).IsRequired();
            Property(u => u.Rating).IsOptional();
        }
    }
}
