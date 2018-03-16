using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class MessageRecipient : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid MessageId { get; set; }
        public virtual string RecipientId { get; set; }
        public MessageStatus MessageStatus { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
