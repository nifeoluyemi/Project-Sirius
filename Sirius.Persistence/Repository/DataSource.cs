using Sirius.Persistence.BusinessObject;
using Sirius.Persistence.Context;
using Sirius.Persistence.IdentityServices.Managers;
using Sirius.Persistence.IdentityServices.Store;
using Sirius.Persistence.Repository.Abstract;
using Sirius.Persistence.Repository.Concrete;
using Sirius.Persistence.UnitofWork.Abstract;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;

namespace Sirius.Persistence.Repository
{
    public class DataSource
    {
        private SiriusContext context;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected SiriusContext dataContext
        {
            get { return context ?? (context = DbFactory.Init()); }
        }

        private BaseRepository<AppraisalDimensionBO> _appraisalDimensionRepository;
        private BaseRepository<AppraisalFormatBO> _appraisalFormatRepository;
        private BaseRepository<AppraisalPeriodBO> _appraisalPeriodRepository;
        private BaseRepository<AppraisalRecommendationBO> _appraisalRecommendationRepository;
        private BaseRepository<DepartmentBO> _departmentRepository;
        private BaseRepository<ErrorBO> _errorRepository;
        private BaseRepository<MessageBO> _messageRepository;
        private BaseRepository<MessageNotificationBO> _messageNotificationRepository;
        private BaseRepository<MessageRecipientBO> _messageRecipientRepository;
        private BaseRepository<NotificationBO> _notificationRepository;
        private BaseRepository<OrganizationBO> _organizationRepository;
        private BaseRepository<OrganizationObjectiveBO> _organizationObjectivesRepository;
        private BaseRepository<OrganizationStaffStatusBO> _organizationStaffStatusRepository;
        private BaseRepository<ReviewNominationBO> _reviewNominationRepository;
        private BaseRepository<TaskBO> _taskRepository;
        private BaseRepository<TaskEvaluationBO> _taskEvaluationRepository;
        private BaseRepository<UserAccountLoginBO> _userAccountLoginRepository;
        private BaseRepository<UserAnnualRecommendationBO> _userAnnualRecommendationRepository;
        private BaseRepository<UserAppraisalApprovalBO> _userAppraisalApprovalRepository;
        private BaseRepository<UserAppraisalBO> _userAppraisalRepository;
        private BaseRepository<UserAppraisalCommentBO> _userAppraisalCommentRepository;
        private BaseRepository<UserAverageReviewBO> _userAverageReviewRepository;
        private BaseRepository<UserDimensionEvaluationBO> _userDimensionEvaluationRepository;
        private BaseRepository<UserReviewBO> _userReviewRepository;
        private BaseRepository<UserStatusBO> _userStatusRepository;
        private BaseRepository<UserTaskBO> _userTaskRepository;
        private BaseRepository<UserTaskEvaluationBO> _userTaskEvaluationRepository;
        private SiriusUserManager userManager;
        private SiriusRoleManager roleManager;

        //var context = request.Properties["MS_HttpContext"] as HttpContextWrapper;
        //HttpContextExtensions.GetOwinContext().GetUserManager<SiriusUserManager>();
        public SiriusUserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = new SiriusUserManager(new SiriusUserStore(dataContext)));
            }
        }

        public SiriusRoleManager RoleManager
        {
            get
            {
                return roleManager ?? (roleManager = new SiriusRoleManager(new SiriusRoleStore(dataContext)));
            }
        }

        public IBaseRepository<AppraisalDimensionBO> appraisalDimensionRepository
        {
            get
            {
                return _appraisalDimensionRepository ?? (_appraisalDimensionRepository = new BaseRepository<AppraisalDimensionBO>(dataContext));
            }
        }

        public IBaseRepository<AppraisalFormatBO> appraisalFormatRepository
        {
            get
            {
                return _appraisalFormatRepository ?? (_appraisalFormatRepository = new BaseRepository<AppraisalFormatBO>(dataContext));
            }
        }

        public IBaseRepository<AppraisalPeriodBO> appraisalPeriodRepository
        {
            get
            {
                return _appraisalPeriodRepository ?? (_appraisalPeriodRepository = new BaseRepository<AppraisalPeriodBO>(dataContext));
            }
        }

        public IBaseRepository<AppraisalRecommendationBO> appraisalRecommendationRepository
        {
            get
            {
                return _appraisalRecommendationRepository ?? (_appraisalRecommendationRepository = new BaseRepository<AppraisalRecommendationBO>(dataContext));
            }
        }

        public IBaseRepository<DepartmentBO> departmentRepository
        {
            get
            {
                return _departmentRepository ?? (_departmentRepository = new BaseRepository<DepartmentBO>(dataContext));
            }
        }

        public IBaseRepository<ErrorBO> errorRepository
        {
            get
            {
                return _errorRepository ?? (_errorRepository = new BaseRepository<ErrorBO>(dataContext));
            }
        }

        public IBaseRepository<MessageBO> messageRepository
        {
            get
            {
                return _messageRepository ?? (_messageRepository = new BaseRepository<MessageBO>(dataContext));
            }
        }

        public IBaseRepository<MessageNotificationBO> messageNotificationRepository
        {
            get
            {
                return _messageNotificationRepository ?? (_messageNotificationRepository = new BaseRepository<MessageNotificationBO>(dataContext));
            }
        }

        public IBaseRepository<MessageRecipientBO> messageRecipientRepository
        {
            get
            {
                return _messageRecipientRepository ?? (_messageRecipientRepository = new BaseRepository<MessageRecipientBO>(dataContext));
            }
        }

        public IBaseRepository<NotificationBO> notificationRepository
        {
            get
            {
                return _notificationRepository ?? (_notificationRepository = new BaseRepository<NotificationBO>(dataContext));
            }
        }

        public IBaseRepository<OrganizationBO> organizationRepository
        {
            get
            {
                return _organizationRepository ?? (_organizationRepository = new BaseRepository<OrganizationBO>(dataContext));
            }
        }

        public IBaseRepository<OrganizationObjectiveBO> organizationObjectivesRepository
        {
            get
            {
                return _organizationObjectivesRepository ?? (_organizationObjectivesRepository = new BaseRepository<OrganizationObjectiveBO>(dataContext));
            }
        }

        public IBaseRepository<OrganizationStaffStatusBO> organizationStaffStatusRepository
        {
            get
            {
                return _organizationStaffStatusRepository ?? (_organizationStaffStatusRepository = new BaseRepository<OrganizationStaffStatusBO>(dataContext));
            }
        }

        public IBaseRepository<ReviewNominationBO> reviewNominationRepository
        {
            get
            {
                return _reviewNominationRepository ?? (_reviewNominationRepository = new BaseRepository<ReviewNominationBO>(dataContext));
            }
        }

        public IBaseRepository<TaskBO> taskRepository
        {
            get
            {
                return _taskRepository ?? (_taskRepository = new BaseRepository<TaskBO>(dataContext));
            }
        }

        public IBaseRepository<TaskEvaluationBO> taskEvaluationRepository
        {
            get
            {
                return _taskEvaluationRepository ?? (_taskEvaluationRepository = new BaseRepository<TaskEvaluationBO>(dataContext));
            }
        }

        public IBaseRepository<UserAccountLoginBO> userAccountLoginRepository
        {
            get
            {
                return _userAccountLoginRepository ?? (_userAccountLoginRepository = new BaseRepository<UserAccountLoginBO>(dataContext));
            }
        }

        public IBaseRepository<UserAnnualRecommendationBO> userAnnualRecommendationRepository
        {
            get
            {
                return _userAnnualRecommendationRepository ?? (_userAnnualRecommendationRepository = new BaseRepository<UserAnnualRecommendationBO>(dataContext));
            }
        }

        public IBaseRepository<UserAppraisalApprovalBO> userAppraisalApprovalRepository
        {
            get
            {
                return _userAppraisalApprovalRepository ?? (_userAppraisalApprovalRepository = new BaseRepository<UserAppraisalApprovalBO>(dataContext));
            }
        }

        public IBaseRepository<UserAppraisalBO> userAppraisalRepository
        {
            get
            {
                return _userAppraisalRepository ?? (_userAppraisalRepository = new BaseRepository<UserAppraisalBO>(dataContext));
            }
        }

        public IBaseRepository<UserAppraisalCommentBO> userAppraisalCommentRepository
        {
            get
            {
                return _userAppraisalCommentRepository ?? (_userAppraisalCommentRepository = new BaseRepository<UserAppraisalCommentBO>(dataContext));
            }
        }

        public IBaseRepository<UserAverageReviewBO> userAverageReviewRepository
        {
            get
            {
                return _userAverageReviewRepository ?? (_userAverageReviewRepository = new BaseRepository<UserAverageReviewBO>(dataContext));
            }
        }

        public IBaseRepository<UserDimensionEvaluationBO> userDimensionEvaluationRepository
        {
            get
            {
                return _userDimensionEvaluationRepository ?? (_userDimensionEvaluationRepository = new BaseRepository<UserDimensionEvaluationBO>(dataContext));
            }
        }

        public IBaseRepository<UserReviewBO> userReviewRepository
        {
            get
            {
                return _userReviewRepository ?? (_userReviewRepository = new BaseRepository<UserReviewBO>(dataContext));
            }
        }

        public IBaseRepository<UserStatusBO> userStatusRepository
        {
            get
            {
                return _userStatusRepository ?? (_userStatusRepository = new BaseRepository<UserStatusBO>(dataContext));
            }
        }

        public IBaseRepository<UserTaskBO> userTaskRepository
        {
            get
            {
                return _userTaskRepository ?? (_userTaskRepository = new BaseRepository<UserTaskBO>(dataContext));
            }
        }

        public IBaseRepository<UserTaskEvaluationBO> userTaskEvaluationRepository
        {
            get
            {
                return _userTaskEvaluationRepository ?? (_userTaskEvaluationRepository = new BaseRepository<UserTaskEvaluationBO>(dataContext));
            }
        }




        //public static BaseRepository<T> Init() 
        //{

        //}

        //public void mess()
        //{
        //    var userManager1 = new SiriusUserManager(new SiriusUserStore(dataContext));

        //    userManager1.cr
        //}
    }
}
