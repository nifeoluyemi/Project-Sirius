using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Sirius.Persistence.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.IdentityServices.Managers
{
    public class SiriusSignInManager : SignInManager<UserBO, string>
    {
        public SiriusSignInManager(SiriusUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserBO user)
        {
            return user.GenerateUserIdentityAsync((SiriusUserManager)UserManager);
        }

        public static SiriusSignInManager Create(IdentityFactoryOptions<SiriusSignInManager> options, IOwinContext context)
        {
            return new SiriusSignInManager(context.GetUserManager<SiriusUserManager>(), context.Authentication);
        }
    }
}
