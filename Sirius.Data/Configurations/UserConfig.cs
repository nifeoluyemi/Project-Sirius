using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.Configurations
{
    public class UserConfig : EntityBaseConfig<UserBO>
    {
        public UserConfig()
        {
            Property(u => u.StaffUserName).IsRequired().HasMaxLength(100);
            Property(u => u.FirstName).IsOptional().HasMaxLength(100);
            Property(u => u.MiddleName).IsOptional().HasMaxLength(100);
            Property(u => u.LastName).IsOptional().HasMaxLength(100);
            Property(u => u.DateOfBirth).IsOptional();

            Property(u => u.ImageContent).IsOptional();
            Property(u => u.ImageMimeType).IsOptional();


            HasMany(u => u.UserTasks).WithRequired(u => u.User).HasForeignKey(u => u.UserId);

            HasMany(u => u.Notifications).WithRequired(u => u.Recipient).HasForeignKey(u => u.RecipientId).WillCascadeOnDelete(false);
            HasMany(u => u.SentNotifications).WithRequired(u => u.Sender).HasForeignKey(u => u.SenderId).WillCascadeOnDelete(false);

            HasMany(u => u.SentMessages).WithRequired(u => u.Sender).HasForeignKey(u => u.SenderId).WillCascadeOnDelete(false);
            HasMany(u => u.IncomingMessages).WithRequired(u => u.Recipient).HasForeignKey(u => u.RecipientId).WillCascadeOnDelete(false);
            //HasMany(u => u.MessageNotifications).WithRequired(u => u.).HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);

            HasMany(u => u.PrivilegeRequests).WithRequired(u => u.User).HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);

        }
    }
}
