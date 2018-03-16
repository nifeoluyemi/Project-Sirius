using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Entity.Enums;

namespace Sirius.Entity.Entities
{
    public class UserProfile : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string UserId { get; set; }
        public ProfileColor ProfileColor { get; set; }
        public virtual Guid UserTimeZoneId { get; set; }
    }
}
