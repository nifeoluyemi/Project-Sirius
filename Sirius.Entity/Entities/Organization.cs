using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class Organization : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }

        public byte[] OrganizationLogo { get; set; }
        public string ImageMimeType { get; set; }

        public Status Status { get; set; }
    }
}
