using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Entity.Entities;
using Sirius.Data.BusinessObject;
using Sirius.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Context
{
    public class SiriusContext : IdentityDbContext<UserBO, RoleBO, string, UserLogin, UserRole, UserClaim>
    {
        public SiriusContext()
            : base("SiriusConnection")
        {
        }

        public IDbSet<ErrorBO> Error { get; set; }
        public IDbSet<MessageBO> Message { get; set; }
        public IDbSet<MessageNotificationBO> MessageNotification { get; set; }
        public IDbSet<MessageRecipientBO> MessageRecipient { get; set; }
        public IDbSet<NotificationBO> Notification { get; set; }
        public IDbSet<OrganizationBO> Organization { get; set; }
        public IDbSet<PrivilegeRequestBO> PrivilegeRequest { get; set; }
        public IDbSet<UserTaskExpectationBO> TaskExpectation { get; set; }
        public IDbSet<UserAccountLoginBO> UserAccountLogin { get; set; }
        public IDbSet<UserProfileBO> UserProfile { get; set; }
        public IDbSet<UserTaskBO> UserTask { get; set; }
        public IDbSet<UserTaskCommentBO> UserTaskComment { get; set; }
        public IDbSet<UserTaskEvaluationBO> UserTaskEvaluation { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Complex type configuration
            modelBuilder.Configurations.Add(new AuditConfig());

            //Entity Type Configuration
            modelBuilder.Configurations.Add(new ErrorConfig());
            modelBuilder.Configurations.Add(new MessageConfig());
            modelBuilder.Configurations.Add(new MessageNotificationConfig());
            modelBuilder.Configurations.Add(new NotificationConfig());
            modelBuilder.Configurations.Add(new OrganizationConfig());
            modelBuilder.Configurations.Add(new UserAccountLoginConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new UserTaskConfig());
            modelBuilder.Configurations.Add(new UserTaskEvaluationConfig());

            base.OnModelCreating(modelBuilder);
        }

        public static SiriusContext Create()
        {
            return new SiriusContext();
        }
    }
}
