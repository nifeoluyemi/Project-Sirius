using Sirius.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Persistence.BusinessObject
{
    [Table("UserStatus")]
    public class UserStatusBO : UserStatus
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

        public override string UserId
        {
            get
            {
                return base.UserId;
            }
            set
            {
                base.UserId = value;
            }
        }

        public override Guid OrganizationStaffStatusId
        {
            get
            {
                return base.OrganizationStaffStatusId;
            }
            set
            {
                base.OrganizationStaffStatusId = value;
            }
        }

        [ForeignKey("UserId")]
        public virtual UserBO User { get; set; }

        [ForeignKey("OrganizationStaffStatusId")]
        public virtual OrganizationStaffStatusBO OrganizationStaffStatus { get; set; }
    }
}
