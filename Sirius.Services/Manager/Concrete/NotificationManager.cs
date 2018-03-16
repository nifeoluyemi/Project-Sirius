using Sirius.Data.BusinessObject;
using Sirius.Data.Repository;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Entity.Enums;
using Sirius.Services.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.Concrete
{
    public class NotificationManager : BaseManager, INotificationManager
    {
        public NotificationManager(IDbFactory _db, IUnitofWork _unitofWork)
            : base(_db, _unitofWork)
        {

        }

        #region Get All Method

        public IQueryable<NotificationBO> Notifications(Expression<Func<NotificationBO, bool>> predicate)
        {
            return db.notificationRepository.FindBy(predicate);
        }


        #endregion


        #region GetSingle Methods

        public ErrorBO GetErrorById(Guid errorId)
        {
            return db.errorRepository.FindBy(e => e.Id == errorId).FirstOrDefault();
        }

        public MessageNotificationBO GetMessageNotificationById(Guid messageNotificationId)
        {
            return db.messageNotificationRepository.FindBy(m => m.Id == messageNotificationId).FirstOrDefault();
        }

        public NotificationBO GetNotificationById(Guid notificationId)
        {
            return db.notificationRepository.FindBy(n => n.Id == notificationId).FirstOrDefault();
        }

        #endregion


        #region Add Entities

        public virtual void Add(ErrorBO error)
        {
            if(error == null)
            {
                throw new ArgumentNullException("error", "Error is null");
            }
            else
            {
                db.errorRepository.Add(error);
                unitofWork.Commit();
            }
        }


        public virtual void Add(MessageNotificationBO messageNotification)
        {
            if(messageNotification == null)
            {
                throw new ArgumentNullException("messageNotification", "Message Notification is null");
            }
            else
            {
                db.messageNotificationRepository.Add(messageNotification);
                unitofWork.Commit();
            }
        }

        public virtual void Add(NotificationBO notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification", "Notification is null");
            }
            else
            {
                db.notificationRepository.Add(notification);
                unitofWork.Commit();
            }
        }

        #endregion 


        #region Update Entities

        public virtual void Update(ErrorBO error)
        {
            if(error == null)
            {
                throw new ArgumentNullException("error", "Error is null");
            }
            else
            {
                db.errorRepository.Edit(error);
                unitofWork.Commit();
            }
        }

        public virtual void Update(MessageNotificationBO messageNotification)
        {
            if (messageNotification == null)
            {
                throw new ArgumentNullException("messageNotification", "Message Notification is null");
            }
            else
            {
                db.messageNotificationRepository.Edit(messageNotification);
                unitofWork.Commit();
            }
        }

        public virtual void Update(NotificationBO notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification", "Notification is null");
            }
            else
            {
                db.notificationRepository.Edit(notification);
                unitofWork.Commit();
            }
        }

        #endregion


        #region Delete Entities

        public virtual void Delete(ErrorBO error, bool purge = false)
        {
            if (purge)
            {
                db.errorRepository.Delete(error);
                unitofWork.Commit();
            }
            else
            {
                error.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(error);
            }
        }

        public virtual void Delete(MessageNotificationBO messageNotification, bool purge = false)
        {
            if (purge)
            {
                db.messageNotificationRepository.Delete(messageNotification);
                unitofWork.Commit();
            }
            else
            {
                messageNotification.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(messageNotification);
            }
        }

        public virtual void Delete(NotificationBO notification, bool purge = false)
        {
            if (purge)
            {
                db.notificationRepository.Delete(notification);
                unitofWork.Commit();
            }
            else
            {
                notification.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(notification);
            }
        }


        #endregion


        #region other methods

        public void Read(MessageNotificationBO messageNotification)
        {
            if (messageNotification != null)
            {
                messageNotification.NotificationState = Entity.Enums.NotificationState.Read;
                messageNotification.ReadDate = DateTime.UtcNow;

                Update(messageNotification);
            }
        }

        public void Read(NotificationBO notification)
        {
            if (notification != null)
            {
                notification.NotificationState = Entity.Enums.NotificationState.Read;
                notification.ReadDate = DateTime.UtcNow;

                Update(notification);
            }
        }

        public void Read(IEnumerable<MessageNotificationBO> messageNotifications)
        {
            if (messageNotifications != null)
            {
                foreach (MessageNotificationBO messageNotification in messageNotifications)
                {
                    Read(messageNotification);
                }
            }
        }

        public void Read(IEnumerable<NotificationBO> notifications)
        {
            if (notifications != null)
            {
                foreach (NotificationBO notification in notifications)
                {
                    Read(notification);
                }
            }
        }


        public IEnumerable<MessageNotificationBO> GetUserMessageNotifications(string userId)
        {
            return db.messageNotificationRepository.FindBy(m => m.Audit.RecordState == Entity.Enums.RecordStateType.Active && m.RecipientId == userId).OrderByDescending(m => m.Audit.CreatedDate);
        }

        public IEnumerable<MessageNotificationBO> GetUserMessageNotifications(string userId, int count)
        {
            return db.messageNotificationRepository.FindBy(m => m.Audit.RecordState == Entity.Enums.RecordStateType.Active && m.RecipientId == userId).OrderByDescending(m => m.Audit.CreatedDate).Take(count);
        }

        public IEnumerable<NotificationBO> GetUserNotifications(string userId)
        {
            return db.notificationRepository.FindBy(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.RecipientId == userId);
        }

        public IEnumerable<NotificationBO> GetUserNotifications(string userId, int count)
        {
            return db.notificationRepository.FindBy(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.RecipientId == userId).OrderByDescending(m => m.Audit.CreatedDate).Take(count);
        }
        //get user read and unread notifs & seen


        public int UserUnreadNotificationCount(string userId)
        {
            return db.notificationRepository.FindBy(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.NotificationState == Entity.Enums.NotificationState.Unread && n.RecipientId == userId).Count();
        }

        public int UserUnreadMessageNotificationCount(string userId)
        {
            return db.messageNotificationRepository.FindBy(m => m.Audit.RecordState == Entity.Enums.RecordStateType.Active && m.NotificationState == Entity.Enums.NotificationState.Unread && m.RecipientId == userId).Count();
        }


        public IEnumerable<NotificationBO> GetNotification(string userId, NotificationState state)
        {
            return db.notificationRepository.FindBy(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.NotificationState == state && n.RecipientId == userId);
        }
        public IEnumerable<NotificationBO> GetNotification(string userId)
        {
            return db.notificationRepository.FindBy(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.RecipientId == userId);
        }

        //get all unread


        #endregion


        #region Asynchronous Methods

        public async Task AddAsync(ErrorBO error)
        {
            if (error == null)
            {
                throw new ArgumentNullException("error", "Error is null");
            }
            else
            {
                db.errorRepository.Add(error);
                await unitofWork.CommitAsync();
            }
        }

        public async Task AddAsync(MessageNotificationBO messageNotification)
        {
            if (messageNotification == null)
            {
                throw new ArgumentNullException("messageNotification", "Message Notification is null");
            }
            else
            {
                db.messageNotificationRepository.Add(messageNotification);
                await unitofWork.CommitAsync();
            }
        }

        public async Task AddAsync(NotificationBO notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException("notification", "Notification is null");
            }
            else
            {
                db.notificationRepository.Add(notification);
                await unitofWork.CommitAsync();
            }
        }

        public async Task UpdateAsync(MessageNotificationBO messageNotification)
        {
            if (messageNotification != null)
            {
                db.messageNotificationRepository.Edit(messageNotification);
                await unitofWork.CommitAsync();
            }
        }

        public async Task UpdateAsync(NotificationBO notification)
        {
            if (notification != null)
            {
                db.notificationRepository.Edit(notification);
                await unitofWork.CommitAsync();
            }
        }



        public async Task<int> UserUnreadNotificationCountAsync(string userId)
        {
            var notifications =  await db.notificationRepository.FindByAsync(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.NotificationState == Entity.Enums.NotificationState.Unread && n.RecipientId == userId);
            return notifications.Count();
        }

        public async Task<int> UserUnreadMessageNotificationCountAsync(string userId)
        {
            var messageNotifications = await db.messageNotificationRepository.FindByAsync(m => m.Audit.RecordState == Entity.Enums.RecordStateType.Active && m.NotificationState == Entity.Enums.NotificationState.Unread && m.RecipientId == userId);
            return messageNotifications.Count();
        }

        public async Task<IEnumerable<MessageNotificationBO>> GetUserMessageNotificationsAsync(string userId)
        {
            return await db.messageNotificationRepository.FindByAsync(m => m.Audit.RecordState == Entity.Enums.RecordStateType.Active && m.RecipientId == userId);
        }

        public async Task<IEnumerable<NotificationBO>> GetUserNotificationsAsync(string userId)
        {
            return await db.notificationRepository.FindByAsync(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.RecipientId == userId);
        }


        public async Task ReadAsync(MessageNotificationBO messageNotification)
        {
            if (messageNotification != null)
            {
                messageNotification.NotificationState = Entity.Enums.NotificationState.Read;
                messageNotification.ReadDate = DateTime.UtcNow;

                await UpdateAsync(messageNotification);
            }
        }

        public async Task ReadAsync(NotificationBO notification)
        {
            if (notification != null)
            {
                notification.NotificationState = Entity.Enums.NotificationState.Read;
                notification.ReadDate = DateTime.UtcNow;

                await UpdateAsync(notification);
            }
        }

        public async Task ReadAsync(List<MessageNotificationBO> messageNotifications)
        {
            if (messageNotifications != null)
            {
                foreach (MessageNotificationBO messageNotification in messageNotifications)
                {
                    await ReadAsync(messageNotification);
                }
            }
        }

        public async Task ReadAsync(List<NotificationBO> notifications)
        {
            if (notifications != null)
            {
                foreach (NotificationBO notification in notifications)
                {
                    await ReadAsync(notification);
                }
            }
        }

        //mark messages as seen & async
        public async Task SeenAsync(MessageNotificationBO messageNotification)
        {
            if (messageNotification != null)
            {
                messageNotification.NotificationState = Entity.Enums.NotificationState.Seen;
                await UpdateAsync(messageNotification);
            }
        }

        public async Task SeenAsync(NotificationBO notification)
        {
            if (notification != null)
            {
                notification.NotificationState = Entity.Enums.NotificationState.Seen;
                await UpdateAsync(notification);
            }
        }

        public async Task SeenAsync(List<MessageNotificationBO> messageNotifications)
        {
            if (messageNotifications != null)
            {
                foreach (MessageNotificationBO messageNotification in messageNotifications)
                {
                    await SeenAsync(messageNotification);
                }
            }
        }

        public async Task SeenAsync(List<NotificationBO> notifications)
        {
            if (notifications != null)
            {
                foreach (NotificationBO notification in notifications)
                {
                    await SeenAsync(notification);
                }
            }
        }

        public async Task<IEnumerable<NotificationBO>> GetNotificationAsync(string userId, NotificationState state)
        {
            return await db.notificationRepository.FindByAsync(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.NotificationState == state && n.RecipientId == userId);
        }

        public async Task<IEnumerable<NotificationBO>> GetNotificationAsync(string userId)
        {
            return await db.notificationRepository.FindByAsync(n => n.Audit.RecordState == Entity.Enums.RecordStateType.Active && n.RecipientId == userId);
        }

        #endregion


        #region Boolean Methods



        #endregion
    }
}
