using Microsoft.AspNet.Identity;
using Sirius.Entity.Entities;
using Sirius.Data.IdentityServices.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.BusinessObject
{
    public class UserBO : User
    {
        public UserBO()
        {
            Id = Guid.NewGuid().ToString();

            Notifications = new HashSet<NotificationBO>();
            SentNotifications = new HashSet<NotificationBO>();
            UserTasks = new HashSet<UserTaskBO>();

            UserTaskComments = new HashSet<UserTaskCommentBO>();
            UserTaskEvaluations = new HashSet<UserTaskEvaluationBO>();

            SentMessages = new HashSet<MessageBO>();
            IncomingMessages = new HashSet<MessageRecipientBO>();
            MessageNotifications = new HashSet<MessageNotificationBO>();

            PrivilegeRequests = new HashSet<PrivilegeRequestBO>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(SiriusUserManager manager)
        {
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("UserId", this.Id));
            userIdentity.AddClaim(new Claim("UserOrganizationId", this.OrganizationId.ToString()));
            userIdentity.AddClaim(new Claim("UserFirstName", this.FirstName ?? ""));
            userIdentity.AddClaim(new Claim("UserLastName", this.LastName ?? ""));
            userIdentity.AddClaim(new Claim("StaffUserName", this.StaffUserName));
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
        public virtual ICollection<NotificationBO> Notifications { get; set; }
        public virtual ICollection<NotificationBO> SentNotifications { get; set; }
        public virtual ICollection<UserTaskBO> UserTasks { get; set; }

        public virtual ICollection<UserTaskCommentBO> UserTaskComments { get; set; }
        public virtual ICollection<UserTaskEvaluationBO> UserTaskEvaluations { get; set; }

        public virtual ICollection<MessageBO> SentMessages { get; set; }
        public virtual ICollection<MessageRecipientBO> IncomingMessages { get; set; }
        public virtual ICollection<MessageNotificationBO> MessageNotifications { get; set; }

        public virtual ICollection<PrivilegeRequestBO> PrivilegeRequests { get; set; }
    }
}
