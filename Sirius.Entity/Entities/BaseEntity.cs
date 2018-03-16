using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class BaseEntity
    {
        //public virtual Guid OrganizationId { get; set; }
        public Audit Audit { get; set; }
    }
}
