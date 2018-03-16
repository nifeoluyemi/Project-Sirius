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
    [Table("Task")]
    public class TaskBO : TaskObjective
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

        public override Guid AppraisalPeriodId
        {
            get
            {
                return base.AppraisalPeriodId;
            }
            set
            {
                base.AppraisalPeriodId = value;
            }
        }

        [ForeignKey("AppraisalPeriodId")]
        public virtual AppraisalPeriodBO AppraisalPeriod { get; set; }
    }
}
