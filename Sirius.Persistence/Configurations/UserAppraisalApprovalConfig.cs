using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAppraisalApprovalConfig : EntityBaseConfig<UserAppraisalApprovalBO>
    {
        public UserAppraisalApprovalConfig()
        {
            Property(u => u.UserAccepted).IsOptional();
            Property(u => u.DateUserAccepted).IsOptional();
            Property(u => u.SupervisorAccepted).IsOptional();
            Property(u => u.DateSupervisorAccepted).IsOptional();
            Property(u => u.HODAccepted).IsOptional();
            Property(u => u.DateHODAccepted).IsOptional();
        }
    }
}
