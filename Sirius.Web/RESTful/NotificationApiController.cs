using Sirius.Data.BusinessObject;
using Sirius.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Entity.Enums;
using Sirius.Services.Manager;
using Sirius.Services.Wrappers;

namespace Sirius.Web.RESTful
{
    public class NotificationApiController : BaseApiController
    {
        public NotificationApiController(IZeus _zeus)
            : base(_zeus)
        {

        }

        //public IEnumerable<NotificationDTO>
        [HttpGet]
        public IHttpActionResult TotalNotifications()
        {
            //IEnumerable<NotificationBO> allNotifications = zeus.notificationManager.GetNotification(CurrentUserId, NotificationState.Unread);
            IEnumerable<NotificationBO> allNotifications = zeus.notificationManager.Notifications(n => n.Audit.RecordState == RecordStateType.Active && n.NotificationState == NotificationState.Unread && n.RecipientId == CurrentUserId)
                .Select(n => new NotificationWrapper { Id = n.Id });
            return Ok(allNotifications.Count());
            
        }

        [HttpGet]
        public IEnumerable<NotificationDTO> GetNotifications()
        {
            try
            {
                IEnumerable<NotificationBO> notifications = zeus.notificationManager.Notifications(n => n.Audit.RecordState == RecordStateType.Active  && n.RecipientId == CurrentUserId)
                    .OrderByDescending(n => n.Audit.CreatedDate)
                    .Select(n => new NotificationWrapper { Id = n.Id, Message = n.Message, URL = n.URL, NotificationState = n.NotificationState, NotificationType = n.NotificationType }).Take(30);
                return NotificationDTO.Map(notifications, zeus);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public IHttpActionResult isNotificationRead(Guid notificationId)
        {
            NotificationBO notification = zeus.notificationManager.GetNotificationById(notificationId);
            bool result = notification.NotificationState == NotificationState.Read ? true : false;
            return Ok(result);
        }

        [HttpPut]
        public async Task<IHttpActionResult> MarkAsRead(Guid notificationId)
        {
            try
            {
                NotificationBO notification = zeus.notificationManager.GetNotificationById(notificationId);
                await zeus.notificationManager.ReadAsync(notification);
                return Ok(notification.URL);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult MarkAllAsRead()
        {
            IEnumerable<NotificationBO> notifications = zeus.notificationManager.Notifications(n => n.Audit.RecordState == RecordStateType.Active && n.NotificationState == NotificationState.Unread && n.RecipientId == CurrentUserId);
            zeus.notificationManager.Read(notifications);
            return Ok();
        }

        public async Task SeeAllNotifications(string userId)
        {
            IEnumerable<NotificationBO> allUnreadNotifications = await zeus.notificationManager.GetNotificationAsync(userId, NotificationState.Unread);
            await zeus.notificationManager.SeenAsync(allUnreadNotifications.ToList());
        }

        //public async Task<>
    }
}
