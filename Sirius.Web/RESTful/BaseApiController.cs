using Sirius.Data.BusinessObject;
using Sirius.Data.IdentityServices.Managers;
using Sirius.Web.Helpers.IdentityHelpers;
using Microsoft.AspNet.Identity;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Sirius.Entity.Enums;
using System.Threading.Tasks;

namespace Sirius.Web.RESTful
{
    public class BaseApiController : ApiController
    {
        public IZeus zeus;
        private SiriusUserManager _userManager;

        public BaseApiController(IZeus _zeus)
        {
            zeus = _zeus;
        }

        public SiriusUserManager UserManager
        {
            get
            {
                return _userManager ?? new SiriusUserManager(new Sirius.Data.IdentityServices.Store.SiriusUserStore(new Sirius.Data.Context.SiriusContext()));
                    //HttpContext.Current.GetOwinContext().GetUserManager<SiriusUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        public Guid CurrentOrganizationId
        {
            get
            {
                return Guid.Parse(User.Identity.GetUserOrganizationId());
            }
        }

        public void LogError(Exception ex, string currentUserId)
        {
            ErrorBO error = new ErrorBO();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            //error.URLAccessed = Request.RawUrl;
            //error.IPAddress = Request.UserHostAddress;
            error.DateCreated = DateTime.UtcNow;
            error.Audit = new Entity.Entities.Audit(currentUserId);

            //AddError
        }

        public void LogError(Exception ex)
        {
            ErrorBO error = new ErrorBO();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            //error.URLAccessed = Request.RawUrl;
            //error.IPAddress = Request.UserHostAddress;
            error.DateCreated = DateTime.UtcNow;
            error.Audit = new Entity.Entities.Audit();

            //AddError
        }

        #region Notification

        public void AddNotification(NotificationType notificationType, string senderId, string recipientId, string notificationUrl)
        {
            try
            {
                NotificationBO notification = new NotificationBO();
                string senderName = "";// senderId == recipientId ? "You" : zeus.staffManager.GetStaffName(senderId);
                string message = null;

                switch (notificationType)
                {
                    case NotificationType.NewTask:
                        message = senderName + " created a New Task.";
                        break;
                    case NotificationType.NewTaskEvaluation:
                        message = senderName + " evaluated one of your Tasks.";
                        break;
                    case NotificationType.Nomination:
                        message = "You have a New Nomination.";
                        break;
                    case NotificationType.NewTaskComment:
                        message = senderName + " comented on one of your Tasks.";
                        break;
                    case NotificationType.TaskAccepted:
                        message = "A Task of yours has been approved.";
                        break;
                    case NotificationType.TaskDeclined:
                        message = "A Task of yours has been declined.";
                        break;
                    case NotificationType.SupervisorRequest:
                        message = senderName + " sent you a Supervisor Request.";
                        break;
                    case NotificationType.SupervisorAccepted:
                        message = senderName + " accepted your request.";
                        break;
                    case NotificationType.SupervisorDeclined:
                        message = senderName + " declined your request.";
                        break;
                    case NotificationType.SupervisorAppraisalApproval:
                        message = "Your Supervisor has approved your appraisal.";
                        break;
                    case NotificationType.HodAppraisalApproval:
                        message = "Your HOD has approved your appraisal.";
                        break;
                    case NotificationType.NewCompetencyEvaluation:
                        message = senderName + " evaluated one of your job competencies.";
                        break;
                    case NotificationType.NewCompetencyComment:
                        message = senderName + " comented on one of your job competencies. ";
                        break;
                    case NotificationType.AppraisalContest:
                        message = senderName + " contested their appraisal result. ";
                        break;
                    default:
                        message = "";
                        break;
                }

                notification.Message = message;
                notification.NotificationState = NotificationState.Unread;
                notification.NotificationType = notificationType;
                notification.SenderId = senderId;
                notification.RecipientId = recipientId;
                notification.URL = notificationUrl;
                notification.Audit = new Entity.Entities.Audit();

                zeus.notificationManager.Add(notification);

            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
            }
        }
        public async Task AddNotificationAsync(NotificationType notificationType, string senderId, string recipientId, string notificationUrl)
        {
            try
            {
                NotificationBO notification = new NotificationBO();
                string senderName = "";// zeus.staffManager.GetStaffName(senderId);
                string message = null;

                switch (notificationType)
                {
                    case NotificationType.NewTask:
                        message = senderName + " just created a New Task.";
                        break;
                    case NotificationType.NewTaskEvaluation:
                        message = senderName + " just Evaluated one of your Tasks.";
                        break;
                    case NotificationType.Nomination:
                        message = "You have a New Nomination.";
                        break;
                    case NotificationType.NewTaskComment:
                        message = senderName + " just comented on one of your Tasks.";
                        break;
                    case NotificationType.TaskAccepted:
                        message = "A Task of yours has been approved.";
                        break;
                    case NotificationType.TaskDeclined:
                        message = "A Task of yours has been declined.";
                        break;
                    case NotificationType.SupervisorRequest:
                        message = senderName + " sent you a Supervisor Request.";
                        break;
                    case NotificationType.SupervisorAccepted:
                        message = senderName + " Accepted your request.";
                        break;
                    case NotificationType.SupervisorDeclined:
                        message = senderName + " Declined your request.";
                        break;
                    case NotificationType.SupervisorAppraisalApproval:
                        message = "Your Supervisor has approved your appraisal.";
                        break;
                    case NotificationType.HodAppraisalApproval:
                        message = "Your HOD has approved your appraisal.";
                        break;
                    case NotificationType.NewCompetencyEvaluation:
                        message = senderName + " just Evaluated one of your job competencies.";
                        break;
                    case NotificationType.NewCompetencyComment:
                        message = senderName + " just comented on one of your job competencies. ";
                        break;
                    case NotificationType.AppraisalContest:
                        message = senderName + " contested their appraisal result. ";
                        break;
                    default:
                        message = "";
                        break;
                }

                notification.Message = message;
                notification.NotificationState = NotificationState.Unread;
                notification.NotificationType = notificationType;
                notification.SenderId = senderId;
                notification.RecipientId = recipientId;
                notification.URL = notificationUrl;
                notification.ReadDate = DateTime.UtcNow;
                notification.Audit = new Entity.Entities.Audit(senderId);


                await zeus.notificationManager.AddAsync(notification);

            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
