using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Sirius.Persistence.BusinessObject;
using Sirius.Persistence.Context;
using Sirius.Persistence.IdentityServices.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.IdentityServices.Managers
{
    public class SiriusRoleManager : RoleManager<RoleBO> //, string>
    {
        public SiriusRoleManager(IRoleStore<RoleBO, string> roleStore)
            : base(roleStore)
        {

        }

        public static SiriusRoleManager Create(IdentityFactoryOptions<SiriusRoleManager> options, IOwinContext context)
        {
            return new SiriusRoleManager(new SiriusRoleStore(context.Get<SiriusContext>()));
        }
    }
}
