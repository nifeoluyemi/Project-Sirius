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
    [Table("UserDimensionEvaluation")]
    public class UserDimensionEvaluationBO : UserDimensionEvaluation
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

        public override Guid AppraisalDimensionId
        {
            get
            {
                return base.AppraisalDimensionId;
            }
            set
            {
                base.AppraisalDimensionId = value;
            }
        }
    }
}
