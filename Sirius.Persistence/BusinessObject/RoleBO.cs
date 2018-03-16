using Sirius.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.BusinessObject
{
    public class RoleBO : Role
    {
        public RoleBO()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public RoleBO(string name)
            : this()
        {
            this.Name = name;
        }
    }
}
