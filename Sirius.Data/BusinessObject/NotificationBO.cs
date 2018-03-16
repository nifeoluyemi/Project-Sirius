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
    [Table("Notification")]
    public class NotificationBO : Notification
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

        public override string SenderId
        {
            get
            {
                return base.SenderId;
            }
            set
            {
                base.SenderId = value;
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

        [ForeignKey("RecipientId")]
        public virtual UserBO Recipient { get; set; }

        [ForeignKey("SenderId")]
        public virtual UserBO Sender { get; set; }
    }
}
