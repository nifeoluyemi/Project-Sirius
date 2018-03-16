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
    [Table("AppraisalFormat")]
    public class AppraisalFormatBO : AppraisalFormat
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

        public override string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
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
    }
}
