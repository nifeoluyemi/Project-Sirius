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
    [Table("OrganizationStaffStatus")]
    public class OrganizationStaffStatusBO : OrganizationStaffStatus
    {
        public OrganizationStaffStatusBO()
        {
            this.Users = new HashSet<UserStatusBO>();
        }

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

        public override string StatusName
        {
            get
            {
                return base.StatusName;
            }
            set
            {
                base.StatusName = value;
            }
        }

        public override Guid OrganizationId
        {
            get
            {
                return base.OrganizationId;
            }
            set
            {
                base.OrganizationId = value;
            }
        }

        [ForeignKey("OrganizationId")]
        public virtual OrganizationBO Organization { get; set; }

        public virtual ICollection<UserStatusBO> Users { get; set; }
    }
}
