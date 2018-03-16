using Microsoft.AspNet.Identity;
using Sirius.Entity.Entities;
using Sirius.Persistence.IdentityServices.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.BusinessObject
{
    public class UserBO : User
    {
        public UserBO()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Statuses = new HashSet<UserStatusBO>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(SiriusUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        [Key]
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public override Guid DepartmentId
        {
            get
            {
                return base.DepartmentId;
            }
            set
            {
                base.DepartmentId = value;
            }
        }

        public override Guid OrganizationId
        {
            get
            {
                return base.OrganizationId;
            }
            set
            {
                base.OrganizationId = value;
            }
        }

        [ForeignKey("OrganizationId")]
        public virtual OrganizationBO Organization { get; set; }

        public ICollection<UserStatusBO> Statuses { get; set; }
    }
}
