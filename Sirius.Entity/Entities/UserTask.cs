using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class UserTask : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string AssignedBy { get; set; }
        public virtual string UserId { get; set; }
        public string Title { get; set; }
        public virtual string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUserAccepted { get; set; }
        public RequestStatus Status { get; set; } 
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
