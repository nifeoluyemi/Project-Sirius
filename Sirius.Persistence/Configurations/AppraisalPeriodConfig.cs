using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class AppraisalPeriodConfig : EntityBaseConfig<AppraisalPeriodBO>
    {
        public AppraisalPeriodConfig()
        {
            Property(a => a.Year).IsOptional();

            HasMany(a => a.Tasks).WithRequired(t => t.AppraisalPeriod).HasForeignKey(t => t.AppraisalPeriodId);
            HasMany(a => a.UserAppraisalComments).WithRequired(a => a.AppraisalPeriod).HasForeignKey(a => a.AppraisalPeriodId);
        }
    }
}
