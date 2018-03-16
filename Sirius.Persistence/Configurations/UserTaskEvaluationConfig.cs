using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserTaskEvaluationConfig : EntityBaseConfig<UserTaskEvaluationBO>
    {
        public UserTaskEvaluationConfig()
        {
            Property(u => u.UserTaskId).IsRequired();
            Property(u => u.EvaluatorRating).IsOptional();
            Property(u => u.EvaluatorComment).IsOptional().HasMaxLength(300);
        }
    }
}
