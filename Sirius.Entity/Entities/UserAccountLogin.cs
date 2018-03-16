using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class UserAccountLogin : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string UserId { get; set; }
        public DateTime LoginDate { get; set; }
        public string IPAddress { get; set; }
        public string ComputerName { get; set; }
    }
}
