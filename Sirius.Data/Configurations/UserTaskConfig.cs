using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class UserTaskConfig : EntityBaseConfig<UserTaskBO>
    {
        public UserTaskConfig()
        {
            Property(u => u.UserId).IsRequired();
            Property(u => u.DateUserAccepted).IsOptional();

            HasMany(u => u.UserTaskEvaluations).WithRequired(u => u.UserTask).HasForeignKey(u => u.UserTaskId).WillCascadeOnDelete(true);
        }
    }
}
