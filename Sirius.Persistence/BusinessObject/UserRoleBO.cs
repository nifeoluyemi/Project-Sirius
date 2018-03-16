using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.BusinessObject
{
    public class UserRoleBO : IdentityUserRole<string>
    {
    }

    public class UserLoginBO : IdentityUserLogin<string>
    {
    }

    public class UserClaimBO : IdentityUserClaim<string>
    {
    }
}
