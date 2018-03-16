using Sirius.Data.BusinessObject;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.IdentityServices.Store;
using Sirius.Data.Repository.Abstract;
using Sirius.Data.Repository.Concrete;
using Sirius.Data.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.UnitofWork.Concrete
{
    public class DbFactory : Disposable, IDbFactory
    {
        SiriusContext dbContext;

        public SiriusContext Init()
        {
            return dbContext ?? (dbContext = new SiriusContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }


        private IBaseRepository<ErrorBO> _errorRepository;
        private IBaseRepository<MessageBO> _messageRepository;
        private IBaseRepository<MessageNotificationBO> _messageNotificationRepository;
        private IBaseRepository<MessageRecipientBO> _messageRecipientRepository;
        private IBaseRepository<NotificationBO> _notificationRepository;
        private IBaseRepository<OrganizationBO> _organizationRepository;
        private IBaseRepository<PrivilegeRequestBO> _privilegeRequestRepository;
        private IBaseRepository<StaffDetailBO> _staffDetailRepository;
        private IBaseRepository<UserTaskExpectationBO> _userTaskExpectationRepository;
        private IBaseRepository<UserAccountLoginBO> _userAccountLoginRepository;
        private IBaseRepository<UserProfileBO> _userProfileRepository;
        private IBaseRepository<UserTaskBO> _userTaskRepository;
        private IBaseRepository<UserTaskCommentBO> _userTaskCommentRepository;
        private IBaseRepository<UserTaskEvaluationBO> _userTaskEvaluationRepository;
        private SiriusUserManager userManager;
        private SiriusRoleManager roleManager;

        //public HttpContextBase HttpContext { get; }

        //public IUnitofWork unitofWork
        //{
        //    get
        //    {
        //        return _unitOfWork ?? (_unitOfWork = new Sirius.Data.UnitofWork.Concrete.UnitofWork());
        //    }
        //}

        public SiriusUserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = new SiriusUserManager(new SiriusUserStore(Init())));
            }
        }

        public SiriusRoleManager RoleManager
        {
            get
            {
                return roleManager ?? (roleManager = new SiriusRoleManager(new SiriusRoleStore(Init())));
            }
        }

        public IBaseRepository<ErrorBO> errorRepository
        {
            get
            {
                return _errorRepository ?? (_errorRepository = new BaseRepository<ErrorBO>(Init()));
            }
        }

        public IBaseRepository<MessageBO> messageRepository
        {
            get
            {
                return _messageRepository ?? (_messageRepository = new BaseRepository<MessageBO>(Init()));
            }
        }

        public IBaseRepository<MessageNotificationBO> messageNotificationRepository
        {
            get
            {
                return _messageNotificationRepository ?? (_messageNotificationRepository = new BaseRepository<MessageNotificationBO>(Init()));
            }
        }

        public IBaseRepository<MessageRecipientBO> messageRecipientRepository
        {
            get
            {
                return _messageRecipientRepository ?? (_messageRecipientRepository = new BaseRepository<MessageRecipientBO>(Init()));
            }
        }

        public IBaseRepository<NotificationBO> notificationRepository
        {
            get
            {
                return _notificationRepository ?? (_notificationRepository = new BaseRepository<NotificationBO>(Init()));
            }
        }

        public IBaseRepository<OrganizationBO> organizationRepository
        {
            get
            {
                return _organizationRepository ?? (_organizationRepository = new BaseRepository<OrganizationBO>(Init()));
            }
        }

        public IBaseRepository<PrivilegeRequestBO> privilegeRequestRepository
        {
            get
            {
                return _privilegeRequestRepository ?? (_privilegeRequestRepository = new BaseRepository<PrivilegeRequestBO>(Init()));
            }
        }

        public IBaseRepository<StaffDetailBO> staffDetailRepository
        {
            get
            {
                return _staffDetailRepository ?? (_staffDetailRepository = new BaseRepository<StaffDetailBO>(Init()));
            }
        }

        public IBaseRepository<UserTaskExpectationBO> userTaskExpectationRepository
        {
            get
            {
                return _userTaskExpectationRepository ?? (_userTaskExpectationRepository = new BaseRepository<UserTaskExpectationBO>(Init()));
            }
        }

        public IBaseRepository<UserAccountLoginBO> userAccountLoginRepository
        {
            get
            {
                return _userAccountLoginRepository ?? (_userAccountLoginRepository = new BaseRepository<UserAccountLoginBO>(Init()));
            }
        }

        public IBaseRepository<UserProfileBO> userProfileRepository
        {
            get
            {
                return _userProfileRepository ?? (_userProfileRepository = new BaseRepository<UserProfileBO>(Init()));
            }
        }

        public IBaseRepository<UserTaskBO> userTaskRepository
        {
            get
            {
                return _userTaskRepository ?? (_userTaskRepository = new BaseRepository<UserTaskBO>(Init()));
            }
        }

        public IBaseRepository<UserTaskCommentBO> userTaskCommentRepository
        {
            get
            {
                return _userTaskCommentRepository ?? (_userTaskCommentRepository = new BaseRepository<UserTaskCommentBO>(Init()));
            }
        }

        public IBaseRepository<UserTaskEvaluationBO> userTaskEvaluationRepository
        {
            get
            {
                return _userTaskEvaluationRepository ?? (_userTaskEvaluationRepository = new BaseRepository<UserTaskEvaluationBO>(Init()));
            }
        }


    }
}
