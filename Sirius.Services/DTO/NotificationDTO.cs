using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Entity.Enums;

namespace Sirius.Services.DTO
{
    public class NotificationDTO
    {
        public Guid NotificationId { get; set; }
        public string Message { get; set; }
        public string SenderId { get; set; }
        public string SenderFullName { get; set; }
        public string RecipientId { get; set; }
        public string RecipientFullName { get; set; }
        public string FontAwesome { get; set; }
        public NotificationState NotificationState { get; set; }
        public int State { get; set; }
        public string Date { get; set; }
        public string Url { get; set; }
        public bool IsRead { get; set; }

        public static NotificationDTO Map(NotificationBO notification, IZeus zeus)
        {
            NotificationDTO self = new NotificationDTO 
            { 
                NotificationId = notification.Id,
                Message = notification.Message,
                Url = notification.URL,
                State = (int)notification.NotificationState,
                //SenderFullName = zeus.staffManager.GetStaffName(notification.SenderId)
                IsRead = notification.NotificationState == NotificationState.Read
            };

            switch (notification.NotificationType)
            {
                case NotificationType.NewTask:
                    self.FontAwesome = "fa fa-briefcase text-aqua";
                    break;
                case NotificationType.NewTaskEvaluation:
                    self.FontAwesome = "fa fa-check-square-o text-green";
                    break;
                case NotificationType.Nomination:
                    self.FontAwesome = "fa fa-trophy text-yellow";
                    break;
                case NotificationType.NewTaskComment:
                    self.FontAwesome = "fa fa-comment-o text-light-blue";
                    break;
                case NotificationType.TaskAccepted:
                    self.FontAwesome = "fa fa-check-circle text-green";
                    break;
                case NotificationType.TaskDeclined:
                    self.FontAwesome = "fa fa-times-circle text-red";
                    break;
                case NotificationType.SupervisorRequest:
                    self.FontAwesome = "fa fa-user-plus text-aqua";
                    break;
                case NotificationType.SupervisorAccepted:
                    self.FontAwesome = "fa fa-user text-green";
                    break;
                case NotificationType.SupervisorDeclined:
                    self.FontAwesome = "fa fa-user-times text-red";
                    break;
                case NotificationType.SupervisorAppraisalApproval:
                    self.FontAwesome = "fa fa-thumbs-o-up text-green";
                    break;
                case NotificationType.HodAppraisalApproval:
                    self.FontAwesome = "fa fa-thumbs-up text-green";
                    break;
                case NotificationType.NewCompetencyEvaluation:
                    self.FontAwesome = "fa fa-check-square-o text-green";
                    break;
                case NotificationType.NewCompetencyComment:
                    self.FontAwesome = "fa fa-comment-o text-light-blue";
                    break;
                case NotificationType.AppraisalContest:
                    self.FontAwesome = "fa fa-times-circle-o";
                    break;
                default:
                    self.FontAwesome = "fa fa-envelope-o";
                    break;
            }
            return self;
        }

        public static NotificationDTO Map(MessageNotificationBO messageNotification, IZeus zeus)
        {
            NotificationDTO self = new NotificationDTO();

            self.FontAwesome = "fa fa-envelope-o";

            return self;
        }

        public static IEnumerable<NotificationDTO> Map(IEnumerable<NotificationBO> notifications, IZeus zeus)
        {
            IList<NotificationDTO> selfs = new List<NotificationDTO>();
            foreach (NotificationBO notification in notifications)
            {
                NotificationDTO self = Map(notification, zeus);
                selfs.Add(self);
            }
            return selfs.AsEnumerable();
        }
    }
}
