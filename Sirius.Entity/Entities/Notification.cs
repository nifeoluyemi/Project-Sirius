using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Notification : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string Message {get;set;}
        public virtual string SenderId { get; set; }
        public virtual string RecipientId { get; set; }
        public string URL { get; set; }
        public NotificationType NotificationType { get; set; }
        public NotificationState NotificationState { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
