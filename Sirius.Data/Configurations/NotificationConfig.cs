using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class NotificationConfig : EntityBaseConfig<NotificationBO>
    {
        public NotificationConfig()
        {
            Property(n => n.Message).IsRequired().HasMaxLength(300);
            Property(n => n.URL).IsOptional().HasMaxLength(1000);

            Property(m => m.ReadDate).IsOptional();
        }
    }
}
