using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserTaskConfig : EntityBaseConfig<UserTaskBO>
    {
        public UserTaskConfig()
        {
            Property(u => u.TaskId).IsRequired();
            Property(u => u.AssignedTo).IsRequired();
            Property(u => u.Expectation).IsOptional().HasMaxLength(500);
            Property(u => u.DateUserAccepted).IsOptional();
        }
    }
}
