using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Sirius.Data.Repository;
using Sirius.Data.BusinessObject;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Store;

namespace Sirius.Web.Helpers.IdentityHelpers
{
    public static class UserExtensions
    {

        public static string GetUserOrganizationId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var claimIdentity = identity as ClaimsIdentity;
            if (claimIdentity != null)
            {
                string organizationId = claimIdentity.FindFirstValue("UserOrganizationId");
                return organizationId;
            }
            return "";
        }

        public static string GetUserFirstname(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("identity");
            var claimIdentity = identity as ClaimsIdentity;
            if (claimIdentity != null)
            {
                string firstName = claimIdentity.FindFirstValue("UserFirstName");
                return string.IsNullOrWhiteSpace(firstName) ? claimIdentity.FindFirstValue(ClaimsIdentity.DefaultNameClaimType) : firstName;
            }
            return string.Empty;
        }

        public static string GetUserFullname(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException("identity");
            var claimIdentity = identity as ClaimsIdentity;
            if (claimIdentity != null)
            {
                string firstName = claimIdentity.FindFirstValue("UserFirstName");
                string lastName = claimIdentity.FindFirstValue("UserLastName");
                return string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName) ? claimIdentity.FindFirstValue(ClaimsIdentity.DefaultNameClaimType) : firstName + " " + lastName;
            }
            return string.Empty;
        }

        public static string GetStaffUsername(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentException("identity");
            
            var claimIdentity = identity as ClaimsIdentity;
            if (claimIdentity != null)
            {
                string staffUserName = claimIdentity.FindFirstValue("StaffUserName");
                return string.IsNullOrWhiteSpace(staffUserName) ? claimIdentity.FindFirstValue(ClaimsIdentity.DefaultNameClaimType) : staffUserName;
            }
            return string.Empty;
        }

    }
}