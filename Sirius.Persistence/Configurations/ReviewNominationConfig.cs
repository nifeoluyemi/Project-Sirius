using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class ReviewNominationConfig : EntityBaseConfig<ReviewNominationBO>
    {
        public ReviewNominationConfig()
        {
            Property(r => r.Message).IsOptional().HasMaxLength(350);
            Property(r => r.ReviewDescription).IsRequired().HasMaxLength(500);
        }
    }
}
