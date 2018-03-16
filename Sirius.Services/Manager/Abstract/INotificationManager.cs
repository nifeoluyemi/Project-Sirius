using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.Abstract
{
    public interface INotificationManager : IBaseManager
    {

        #region Get All Method

        IQueryable<NotificationBO> Notifications(Expression<Func<NotificationBO, bool>> predicate);

        #endregion


        #region GetSingle Methods

        ErrorBO GetErrorById(Guid errorId);
        MessageNotificationBO GetMessageNotificationById(Guid messageNotificationId);
        NotificationBO GetNotificationById(Guid notificationId);

        #endregion


        #region Add Entities

        void Add(ErrorBO error);
        void Add(MessageNotificationBO messageNotification);
        void Add(NotificationBO notification);
        
        #endregion


        #region Update Entities
        
        void Update(ErrorBO error);
        void Update(MessageNotificationBO messageNotification);
        void Update(NotificationBO notification);
        #endregion


        #region Delete Entities
        
        void Delete(ErrorBO error, bool purge = false);
        void Delete(MessageNotificationBO messageNotification, bool purge = false);
        void Delete(NotificationBO notification, bool purge = false);

        #endregion


        #region other methods

        void Read(MessageNotificationBO messageNotification);
        void Read(NotificationBO notification);
        void Read(IEnumerable<MessageNotificationBO> messageNotifications);
        void Read(IEnumerable<NotificationBO> notifications);

        IEnumerable<MessageNotificationBO> GetUserMessageNotifications(string userId);
        IEnumerable<MessageNotificationBO> GetUserMessageNotifications(string userId, int count);
        IEnumerable<NotificationBO> GetUserNotifications(string userId);
        IEnumerable<NotificationBO> GetUserNotifications(string userId, int count);
        int UserUnreadNotificationCount(string userId);
        int UserUnreadMessageNotificationCount(string userId);

        IEnumerable<NotificationBO> GetNotification(string userId, NotificationState state);

        IEnumerable<NotificationBO> GetNotification(string userId);

        #endregion


        #region Asynchronous Methods

        Task AddAsync(ErrorBO error);
        Task AddAsync(MessageNotificationBO messageNotification);
        Task AddAsync(NotificationBO notification);
        Task UpdateAsync(MessageNotificationBO messageNotification);
        Task UpdateAsync(NotificationBO notification);


        Task<int> UserUnreadNotificationCountAsync(string userId);
        Task<int> UserUnreadMessageNotificationCountAsync(string userId);
        Task<IEnumerable<MessageNotificationBO>> GetUserMessageNotificationsAsync(string userId);
        Task<IEnumerable<NotificationBO>> GetUserNotificationsAsync(string userId);


        Task ReadAsync(MessageNotificationBO messageNotification);
        Task ReadAsync(NotificationBO notification);
        Task ReadAsync(List<MessageNotificationBO> messageNotifications);
        Task ReadAsync(List<NotificationBO> notifications);
        Task SeenAsync(MessageNotificationBO messageNotification);
        Task SeenAsync(NotificationBO notification);
        Task SeenAsync(List<MessageNotificationBO> messageNotifications);
        Task SeenAsync(List<NotificationBO> notifications);

        Task<IEnumerable<NotificationBO>> GetNotificationAsync(string userId, NotificationState state);
        Task<IEnumerable<NotificationBO>> GetNotificationAsync(string userId);

        #endregion


        #region Boolean Methods



        #endregion
    }
}
