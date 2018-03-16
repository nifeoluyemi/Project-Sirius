using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class MessageNotificationConfig : EntityBaseConfig<MessageNotificationBO>
    {
        public MessageNotificationConfig()
        {
            Property(m => m.Message).IsRequired().HasMaxLength(300);
            Property(m => m.URL).IsOptional().HasMaxLength(1000);

            Property(m => m.ReadDate).IsOptional();
        }
    }
}
