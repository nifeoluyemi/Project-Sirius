using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.IdentityServices.Store
{
    public class SiriusRoleStore : RoleStore<RoleBO, string, UserRole>, IQueryableRoleStore<RoleBO, string>, IRoleStore<RoleBO, string>, IDisposable
    {
        public SiriusRoleStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public SiriusRoleStore(DbContext context)
            : base(context)
        {

        }
    }
}
