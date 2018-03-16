using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Configurations
{
    public class UserAccountLoginConfig : EntityBaseConfig<UserAccountLoginBO>
    {
        public UserAccountLoginConfig()
        {
            Property(u => u.UserId).IsRequired();
            Property(u => u.IPAddress).IsOptional();
            Property(u => u.ComputerName).IsOptional();
        }
    }
}
