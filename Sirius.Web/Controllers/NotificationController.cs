using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Models;
using Sirius.Web.Infrastructure.Attributes;
using Sirius.Services.Manager;

namespace Sirius.Web.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
        //IZeus zeus;
        public NotificationController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: Notification
        public ActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public async Task<int> TotalNotifications()
        {
            IEnumerable<NotificationBO> unreadNotifications = await zeus.notificationManager.GetNotificationAsync(CurrentUserId, NotificationState.Unread);
            int count = unreadNotifications.Count();
            return count;
        }

        [AjaxRequestOnly]
        public async Task<ActionResult> GetNotifications()
        {
            List<NotificationDTO> notifications = new List<NotificationDTO>();
            IEnumerable<NotificationBO> allnotifications = await zeus.notificationManager.GetNotificationAsync(CurrentUserId);
            allnotifications = allnotifications.OrderByDescending(n => n.Audit.CreatedDate);
            IEnumerable<NotificationBO> fiveNotifications = allnotifications.Take(5);
            notifications = NotificationDTO.Map(fiveNotifications, zeus).ToList();

            return PartialView(notifications);
        }

        [AjaxRequestOnly]
        public async Task<ActionResult> ViewAllNotifications()
        {
            List<NotificationDTO> notifications = new List<NotificationDTO>();
            IEnumerable<NotificationBO> allnotifications = await zeus.notificationManager.GetNotificationAsync(CurrentUserId);
            allnotifications = allnotifications.OrderByDescending(n => n.Audit.CreatedDate);
            notifications = NotificationDTO.Map(allnotifications, zeus).ToList();

            return PartialView(notifications);
        }

        public async Task MarkAsSeen()
        {
            IEnumerable<NotificationBO> notifications = await zeus.notificationManager.GetUserNotificationsAsync(CurrentUserId);
            await zeus.notificationManager.SeenAsync(notifications.ToList());
        }

        public async Task<ActionResult> MarkAsRead(Guid notificationId)
        {
            NotificationBO notification = await Task.Run(() => zeus.notificationManager.GetNotificationById(notificationId));
            await zeus.notificationManager.ReadAsync(notification);
            return Redirect(notification.URL);
        }

        public async Task MarkAllAsRead()
        {
            IEnumerable<NotificationBO> notifications = await zeus.notificationManager.GetUserNotificationsAsync(CurrentUserId);
            await zeus.notificationManager.ReadAsync(notifications.ToList());
        }
    }
}