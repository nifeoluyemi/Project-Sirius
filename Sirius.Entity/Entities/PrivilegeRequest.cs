using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class PrivilegeRequest : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string UserId { get; set; }
        public string RoleName { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual Guid DepartmentId { get; set; }
        public virtual Guid OrganizationId { get; set; }
    }
}
