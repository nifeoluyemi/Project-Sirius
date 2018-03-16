using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class UserTaskExpectation : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserTaskId { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }
        public bool IsAccepted { get; set; }
    }
}
