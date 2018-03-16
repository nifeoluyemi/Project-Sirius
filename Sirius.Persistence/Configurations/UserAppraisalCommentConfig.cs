using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAppraisalCommentConfig : EntityBaseConfig<UserAppraisalCommentBO>
    {
        public UserAppraisalCommentConfig()
        {
            Property(a => a.Comment).IsOptional().HasMaxLength(500);
        }
    }
}
