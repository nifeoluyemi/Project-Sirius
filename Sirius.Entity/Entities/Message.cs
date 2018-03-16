using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Message : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string SenderId { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
