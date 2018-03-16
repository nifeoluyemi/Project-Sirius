using Microsoft.AspNet.Identity;
using Sirius.Persistence.BusinessObject;
using Sirius.Persistence.IdentityServices.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.IdentityServices.Validators
{
    public class SiriusUserValidator : UserValidator<UserBO, string>
    {
        public SiriusUserValidator(SiriusUserManager userManager)
            : base(userManager)
        {

        }
    }
}
