using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Persistence.BusinessObject;
using Sirius.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.Context
{
    public class SiriusContext : IdentityDbContext<UserBO, RoleBO, string, Sirius.Entity.Entities.UserLogin, Sirius.Entity.Entities.UserRole, Sirius.Entity.Entities.UserClaim>
    {
        public SiriusContext()
            : base("SiriusConnection")
        {
        }

        public IDbSet<AppraisalDimensionBO> AppraisalDimension { get; set; }
        public IDbSet<AppraisalFormatBO> AppraisalFormat { get; set; }
        public IDbSet<AppraisalPeriodBO> AppraisalPeriod { get; set; }
        public IDbSet<AppraisalRecommendationBO> AppraisalRecommendation { get; set; }
        public IDbSet<DepartmentBO> Department { get; set; }
        public IDbSet<ErrorBO> Error { get; set; }
        public IDbSet<MessageBO> Message { get; set; }
        public IDbSet<MessageNotificationBO> MessageNotification { get; set; }
        public IDbSet<MessageRecipientBO> MessageRecipient { get; set; }
        public IDbSet<NotificationBO> Notification { get; set; }
        public IDbSet<OrganizationBO> Organization { get; set; }
        public IDbSet<OrganizationObjectiveBO> OrganizationObjective { get; set; }
        public IDbSet<OrganizationStaffStatusBO> OrganizationStaffStatus { get; set; }
        public IDbSet<ReviewNominationBO> ReviewNomination { get; set; }
        public IDbSet<TaskBO> Task { get; set; }
        public IDbSet<TaskEvaluationBO> TaskEvaluation { get; set; }
        public IDbSet<UserAccountLoginBO> UserAccountLogin { get; set; }
        public IDbSet<UserAnnualRecommendationBO> UserAnnualRecommendation { get; set; }
        public IDbSet<UserAppraisalApprovalBO> UserAppraisalApproval { get; set; }
        public IDbSet<UserAppraisalBO> UserAppraisal { get; set; }
        public IDbSet<UserAppraisalCommentBO> UserAppraisalComment { get; set; }
        public IDbSet<UserAverageReviewBO> UserAverageReview { get; set; }
        public IDbSet<UserDimensionEvaluationBO> UserDimensionEvaluation { get; set; }
        public IDbSet<UserReviewBO> UserReview { get; set; }
        public IDbSet<UserStatusBO> UserStatus { get; set; }
        public IDbSet<UserTaskBO> UserTask { get; set; }
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
            modelBuilder.Configurations.Add(new AppraisalDimensionConfig());
            modelBuilder.Configurations.Add(new AppraisalFormatConfig());
            modelBuilder.Configurations.Add(new AppraisalPeriodConfig());
            modelBuilder.Configurations.Add(new AppraisalRecommendationConfig());
            modelBuilder.Configurations.Add(new DepartmentConfig());
            modelBuilder.Configurations.Add(new ErrorConfig());
            modelBuilder.Configurations.Add(new MessageConfig());
            modelBuilder.Configurations.Add(new MessageNotificationConfig());
            modelBuilder.Configurations.Add(new NotificationConfig());
            modelBuilder.Configurations.Add(new OrganizationConfig());
            modelBuilder.Configurations.Add(new OrganizationObjectivesConfig());
            modelBuilder.Configurations.Add(new OrganizationStaffStatusConfig());
            modelBuilder.Configurations.Add(new ReviewNominationConfig());
            modelBuilder.Configurations.Add(new TaskConfig());
            modelBuilder.Configurations.Add(new TaskEvaluationConfig());
            modelBuilder.Configurations.Add(new UserAccountLoginConfig());
            modelBuilder.Configurations.Add(new UserAnnualRecommendationConfig());
            modelBuilder.Configurations.Add(new UserAppraisalApprovalConfig());
            modelBuilder.Configurations.Add(new UserAppraisalConfig());
            modelBuilder.Configurations.Add(new UserAppraisalCommentConfig());
            modelBuilder.Configurations.Add(new UserAverageReviewConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new UserDimensionEvaluationConfig());
            modelBuilder.Configurations.Add(new UserReviewConfig());
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
