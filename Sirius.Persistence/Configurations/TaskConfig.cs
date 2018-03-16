using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class TaskConfig : EntityBaseConfig<TaskBO>
    {
        public TaskConfig()
        {
            Property(t => t.Description).IsRequired().HasMaxLength(500);
            Property(t => t.AssignedBy).IsRequired();
        }
    }
}
