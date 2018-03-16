using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class TaskEvaluationConfig : EntityBaseConfig<TaskEvaluationBO>
    {
        public TaskEvaluationConfig()
        {
            Property(t => t.UserTaskId).IsRequired();
            Property(t => t.AverageRating).IsOptional();
            Property(t => t.SelfRatingAverage).IsOptional();

            Property(t => t.BarrierToPerformance).IsOptional().HasMaxLength(300);
            Property(t => t.WayToOvercomeBarriers).IsOptional().HasMaxLength(300);
            Property(t => t.SurpervisorComment).IsOptional().HasMaxLength(300);
        }
    }
}
