using Sirius.Data.BusinessObject;
using Sirius.Data.Context;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.UnitofWork.Abstract
{
    public interface IDbFactory : IDisposable
    {
        SiriusContext Init();

        SiriusUserManager UserManager { get; }
        SiriusRoleManager RoleManager { get; }
        IBaseRepository<ErrorBO> errorRepository { get; }
        IBaseRepository<MessageBO> messageRepository { get; }
        IBaseRepository<MessageNotificationBO> messageNotificationRepository { get; }
        IBaseRepository<MessageRecipientBO> messageRecipientRepository { get; }
        IBaseRepository<NotificationBO> notificationRepository { get; }
        IBaseRepository<OrganizationBO> organizationRepository { get; }
        IBaseRepository<PrivilegeRequestBO> privilegeRequestRepository { get; }
        IBaseRepository<StaffDetailBO> staffDetailRepository { get; }
        IBaseRepository<UserTaskExpectationBO> userTaskExpectationRepository { get; }
        IBaseRepository<UserAccountLoginBO> userAccountLoginRepository { get; }
        IBaseRepository<UserProfileBO> userProfileRepository { get; }
        IBaseRepository<UserTaskBO> userTaskRepository { get; }
        IBaseRepository<UserTaskCommentBO> userTaskCommentRepository { get; }
        IBaseRepository<UserTaskEvaluationBO> userTaskEvaluationRepository { get; }

    }
}
