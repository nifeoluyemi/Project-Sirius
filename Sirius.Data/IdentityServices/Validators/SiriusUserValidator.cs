using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Data.IdentityServices.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.IdentityServices.Validators
{
    public class SiriusUserValidator : UserValidator<UserBO, string>
    {
        public SiriusUserValidator(SiriusUserManager userManager)
            : base(userManager)
        {

        }
    }
}
