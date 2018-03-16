using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class MessageConfig : EntityBaseConfig<MessageBO>
    {
        public MessageConfig()
        {
            Property(m => m.Subject).IsOptional().HasMaxLength(200);
            Property(m => m.MessageBody).IsRequired().IsMaxLength();
        }
    }
}
