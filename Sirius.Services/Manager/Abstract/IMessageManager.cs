using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.Abstract
{
    public interface IMessageManager : IBaseManager
    {

        #region Get All Method


        #endregion

        #region Get Entities




        #endregion


        #region Get Single Methods




        #endregion


        #region Add Entities

        void Add(MessageBO message);
        void Add(MessageRecipientBO messageRecipient);


        #endregion


        #region Update Entities

        void Update(MessageBO message);
        void Update(MessageRecipientBO messageRecipient);


        #endregion


        #region Delete Entities

        void Delete(MessageBO message, bool purge = false);
        void Delete(MessageRecipientBO messageRecipient, bool purge = false);


        #endregion


        #region Other Get Methods

        IEnumerable<MessageRecipientBO> GetUserMessages(string userId);
        IEnumerable<UserBO> GetMessageRecipients(Guid messageId);
        IEnumerable<MessageBO> GetUserSentMessages(string userId);

        #endregion


        #region Asynchronous Methods

        Task<IEnumerable<MessageRecipientBO>> GetUserMessagesAsync(string userId);
        Task<IEnumerable<UserBO>> GetMessageRecipientsAsync(Guid messageId);


        #endregion

    }
}
