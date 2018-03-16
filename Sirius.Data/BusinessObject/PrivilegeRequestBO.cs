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
    [Table("PrivilegeRequest")]
    public class PrivilegeRequestBO : PrivilegeRequest
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

        public override Guid DepartmentId
        {
            get
            {
                return base.DepartmentId;
            }
            set
            {
                base.DepartmentId = value;
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

        [ForeignKey("UserId")]
        public virtual UserBO User { get; set; }

        [ForeignKey("OrganizationId")]
        public virtual OrganizationBO Organization { get; set; }
    }
}
