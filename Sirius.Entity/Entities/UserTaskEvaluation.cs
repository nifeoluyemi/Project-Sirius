using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Entity.Entities
{
    public class UserTaskEvaluation : BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserTaskId { get; set; }
        public virtual string EvaluatorId { get; set; }
        public double Rating { get; set; }
        public double MaximumRating { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
