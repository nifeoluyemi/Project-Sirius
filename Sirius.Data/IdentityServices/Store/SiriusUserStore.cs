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
    public class SiriusUserStore : UserStore<UserBO, RoleBO, string, UserLogin, UserRole, UserClaim>, IUserStore<UserBO, string>, IDisposable
    {
        public SiriusUserStore()
            : this(new IdentityDbContext())
        {

        }

        public SiriusUserStore(DbContext context)
            : base(context)
        {

        }
    }
}
