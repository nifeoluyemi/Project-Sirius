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
    [Table("Department")]
    public class DepartmentBO : Department
    {
        public DepartmentBO()
        {
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

        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        public override string ShortName
        {
            get
            {
                return base.ShortName;
            }
            set
            {
                base.ShortName = value;
            }
        }

        public override string HeadofDepartmentId
        {
            get
            {
                return base.HeadofDepartmentId;
            }
            set
            {
                base.HeadofDepartmentId = value;
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
    }
}
