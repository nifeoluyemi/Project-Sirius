using Sirius.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Data.BusinessObject
{
    [Table("MessageNotification")]
    public class MessageNotificationBO : MessageNotification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public override string RecipientId
        {
            get
            {
                return base.RecipientId;
            }
            set
            {
                base.RecipientId = value;
            }
        }
    }
}
