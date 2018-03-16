using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        public string StaffUserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JobDescription { get; set; }
        public virtual Guid OrganizationId { get; set; }

        public Gender Gender { get; set; }
        public bool HasAcceptedTerms { get; set; }
        public byte[] ImageContent { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageUrl { get; set; }

        public Audit Audit { get; set; }

    }
}
