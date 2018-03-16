using Sirius.Data.BusinessObject;
using Sirius.Data.Repository;
using Sirius.Services.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Sirius.Data.UnitofWork.Abstract;

namespace Sirius.Services.Manager.Concrete
{
    public class MessageManager : BaseManager, IMessageManager
    {
        public MessageManager(IDbFactory _db, IUnitofWork _unitofWork)
            : base(_db, _unitofWork)
        {

        }


        #region Get All Method


        #endregion


        #region Get Entities




        #endregion


        #region Get Single Methods




        #endregion


        #region Add Entities

        public virtual void Add(MessageBO message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message", "Message is null");
            }
            else
            {
                db.messageRepository.Add(message);
                unitofWork.Commit();
            }
        }

        public virtual void Add(MessageRecipientBO messageRecipient)
        {
            if (messageRecipient == null)
            {
                throw new ArgumentNullException("messageRecipient", "Message Recipient is null");
            }
            else
            {
                db.messageRecipientRepository.Add(messageRecipient);
                unitofWork.Commit();
            }
        }


        #endregion


        #region Update Entities

        public virtual void Update(MessageBO message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message", "Message is null");
            }
            else
            {
                db.messageRepository.Edit(message);
                unitofWork.Commit();
            }
        }

        public virtual void Update(MessageRecipientBO messageRecipient)
        {
            if (messageRecipient == null)
            {
                throw new ArgumentNullException("messageRecipient", "Message Recipient is null");
            }
            else
            {
                db.messageRecipientRepository.Edit(messageRecipient);
                unitofWork.Commit();
            }
        }



        #endregion


        #region Delete Entities

        public virtual void Delete(MessageBO message, bool purge = false)
        {
            if (purge)
            {
                db.messageRepository.Delete(message);
                unitofWork.Commit();
            }
            else
            {
                message.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(message);
            }
        }

        public virtual void Delete(MessageRecipientBO messageRecipient, bool purge = false)
        {
            if (purge)
            {
                db.messageRecipientRepository.Delete(messageRecipient);
                unitofWork.Commit();
            }
            else
            {
                messageRecipient.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(messageRecipient);
            }
        }



        #endregion


        #region Other Get Methods

        public IEnumerable<MessageRecipientBO> GetUserMessages(string userId)
        {
            return db.messageRecipientRepository.FindBy(m => m.RecipientId == userId && m.Audit.RecordState == Entity.Enums.RecordStateType.Active);
        }

        public IEnumerable<MessageBO> GetUserSentMessages(string userId)
        {
            return db.messageRepository.FindBy(m => m.SenderId == userId && m.Audit.RecordState == Entity.Enums.RecordStateType.Active);
        }

        public IEnumerable<UserBO> GetMessageRecipients(Guid messageId)
        {
            List<UserBO> recipients = new List<UserBO>();
            IEnumerable<MessageRecipientBO> messageRecipients = db.messageRecipientRepository.FindBy(m => m.MessageId == messageId && m.Audit.RecordState == Entity.Enums.RecordStateType.Active);
            foreach (MessageRecipientBO messageRecipient in messageRecipients)
            {
                UserBO recipient = db.UserManager.Users.Where(u => u.Id == messageRecipient.RecipientId && u.Audit.RecordState == Entity.Enums.RecordStateType.Active).FirstOrDefault();
                recipients.Add(recipient);
            }
            return recipients.AsEnumerable();
        }

        #endregion


        #region Asynchronous Methods

        public async Task<IEnumerable<MessageRecipientBO>> GetUserMessagesAsync(string userId)
        {
            return await db.messageRecipientRepository.FindByAsync(m => m.RecipientId == userId && m.Audit.RecordState == Entity.Enums.RecordStateType.Active);
        }

        public async Task<IEnumerable<UserBO>> GetMessageRecipientsAsync(Guid messageId)
        {
            List<UserBO> recipients = new List<UserBO>();
            IEnumerable<MessageRecipientBO> messageRecipients = db.messageRecipientRepository.FindBy(m => m.MessageId == messageId && m.Audit.RecordState == Entity.Enums.RecordStateType.Active);
            foreach (MessageRecipientBO messageRecipient in messageRecipients)
            {
                UserBO recipient = await db.UserManager.FindByIdAsync(messageRecipient.RecipientId).ConfigureAwait(false);
                recipients.Add(recipient);
            }
            return recipients.AsEnumerable();
        }

        #endregion

    }
}
