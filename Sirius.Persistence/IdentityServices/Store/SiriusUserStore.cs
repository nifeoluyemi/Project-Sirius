using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Entity.Entities;
using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.IdentityServices.Store
{
    public class SiriusUserStore : UserStore<UserBO, RoleBO, string, UserLogin, UserRole, UserClaim>, IUserStore<UserBO, string>, IDisposable
    {
        public SiriusUserStore() 
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public SiriusUserStore(DbContext context)
            : base(context)
        {

        }
    }
}
