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
    [Table("UserTaskEvaluation")]
    public class UserTaskEvaluationBO : UserTaskEvaluation
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

        public override Guid UserTaskId
        {
            get
            {
                return base.UserTaskId;
            }
            set
            {
                base.UserTaskId = value;
            }
        }

        public override string EvaluatorId
        {
            get
            {
                return base.EvaluatorId;
            }
            set
            {
                base.EvaluatorId = value;
            }
        }

        [ForeignKey("EvaluatorId")]
        public virtual UserBO Evaluator { get; set; }

        [ForeignKey("UserTaskId")]
        public virtual UserTaskBO UserTask { get; set; }
    }
}
