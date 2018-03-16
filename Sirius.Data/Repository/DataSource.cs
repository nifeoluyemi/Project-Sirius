using Sirius.Data.BusinessObject;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.IdentityServices.Store;
using Sirius.Data.Repository.Abstract;
using Sirius.Data.Repository.Concrete;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Data.UnitofWork.Concrete;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;

namespace Sirius.Data.Repository
{
    public class DataSource
    {
        //private SiriusContext
        protected IDbFactory DbFactory
        {
            get
            {
                return _dbFactory ?? (_dbFactory = new DbFactory());
            }
        }

        protected SiriusContext dataContext
        {
            get
            {
                return dataContext ?? (DbFactory.Init());
            }
        }

        private DbFactory _dbFactory;
        private Sirius.Data.UnitofWork.Concrete.UnitofWork _unitOfWork;
        private BaseRepository<ErrorBO> _errorRepository;
        private BaseRepository<MessageBO> _messageRepository;
        private BaseRepository<MessageNotificationBO> _messageNotificationRepository;
        private BaseRepository<MessageRecipientBO> _messageRecipientRepository;
        private BaseRepository<NotificationBO> _notificationRepository;
        private BaseRepository<OrganizationBO> _organizationRepository;
        private BaseRepository<PrivilegeRequestBO> _privilegeRequestRepository;
        private BaseRepository<UserTaskExpectationBO> _taskExpectationRepository;
        private BaseRepository<UserAccountLoginBO> _userAccountLoginRepository;
        private BaseRepository<UserProfileBO> _userProfileRepository;
        private BaseRepository<UserTaskBO> _userTaskRepository;
        private BaseRepository<UserTaskCommentBO> _userTaskCommentRepository;
        private BaseRepository<UserTaskEvaluationBO> _userTaskEvaluationRepository;
        private BaseRepository<StaffDetailBO> _staffDetailRepository;
        private SiriusUserManager userManager;
        private SiriusRoleManager roleManager;

        //public HttpContextBase HttpContext { get; }

        public IUnitofWork unitofWork
        {
            get
            {
                return _unitOfWork ?? (_unitOfWork = new Sirius.Data.UnitofWork.Concrete.UnitofWork(DbFactory));
            }
        }

        public SiriusUserManager UserManager
        {
            get
            {
                return userManager ?? (userManager = new SiriusUserManager(new SiriusUserStore(DbFactory.Init())));
            }
        }

        public SiriusRoleManager RoleManager
        {
            get
            {
                return roleManager ?? (roleManager = new SiriusRoleManager(new SiriusRoleStore(DbFactory.Init())));
            }
        }

        
        public IBaseRepository<ErrorBO> errorRepository
        {
            get
            {
                return _errorRepository ?? (_errorRepository = new BaseRepository<ErrorBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<MessageBO> messageRepository
        {
            get
            {
                return _messageRepository ?? (_messageRepository = new BaseRepository<MessageBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<MessageNotificationBO> messageNotificationRepository
        {
            get
            {
                return _messageNotificationRepository ?? (_messageNotificationRepository = new BaseRepository<MessageNotificationBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<MessageRecipientBO> messageRecipientRepository
        {
            get
            {
                return _messageRecipientRepository ?? (_messageRecipientRepository = new BaseRepository<MessageRecipientBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<NotificationBO> notificationRepository
        {
            get
            {
                return _notificationRepository ?? (_notificationRepository = new BaseRepository<NotificationBO>(DbFactory.Init()));
            }
        }


        public IBaseRepository<OrganizationBO> organizationRepository
        {
            get
            {
                return _organizationRepository ?? (_organizationRepository = new BaseRepository<OrganizationBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<PrivilegeRequestBO> privilegeRequestRepository
        {
            get
            {
                return _privilegeRequestRepository ?? (_privilegeRequestRepository = new BaseRepository<PrivilegeRequestBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<UserTaskExpectationBO> taskExpectationRepository
        {
            get
            {
                return _taskExpectationRepository ?? (_taskExpectationRepository = new BaseRepository<UserTaskExpectationBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<UserAccountLoginBO> userAccountLoginRepository
        {
            get
            {
                return _userAccountLoginRepository ?? (_userAccountLoginRepository = new BaseRepository<UserAccountLoginBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<UserProfileBO> userProfileRepository
        {
            get
            {
                return _userProfileRepository ?? (_userProfileRepository = new BaseRepository<UserProfileBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<UserTaskBO> userTaskRepository
        {
            get
            {
                return _userTaskRepository ?? (_userTaskRepository = new BaseRepository<UserTaskBO>(DbFactory.Init()));
            }
        }


        public IBaseRepository<UserTaskCommentBO> userTaskCommentRepository
        {
            get
            {
                return _userTaskCommentRepository ?? (_userTaskCommentRepository = new BaseRepository<UserTaskCommentBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<UserTaskEvaluationBO> userTaskEvaluationRepository
        {
            get
            {
                return _userTaskEvaluationRepository ?? (_userTaskEvaluationRepository = new BaseRepository<UserTaskEvaluationBO>(DbFactory.Init()));
            }
        }

        public IBaseRepository<StaffDetailBO> staffDetailRepository
        {
            get
            {
                return _staffDetailRepository ?? (_staffDetailRepository = new BaseRepository<StaffDetailBO>(DbFactory.Init()));
            }
        }

        //public void Save()
        //{
        //    context.Commit();
        //}

        //public async Task SaveAsync()
        //{
        //    await context.CommitAsync();
        //}

        //public static BaseRepository<T> Init() 
        //{

        //}

        //public void Dispose()
        //{
        //    dataContext.Dispose();
        //}
    }
}
