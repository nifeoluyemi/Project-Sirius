using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserReviewConfig : EntityBaseConfig<UserReviewBO>
    {
        public UserReviewConfig()
        {
            Property(u => u.Rating).IsOptional();
            Property(u => u.ReviewComment).IsOptional().HasMaxLength(300);
        }
    }
}
