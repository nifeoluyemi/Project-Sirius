using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Error : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string IPAddress { get; set; }
        public string URLAccessed { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
