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
    [Table("UserTask")]
    public class UserTaskBO : UserTask
    {
        public UserTaskBO()
        {
            UserTaskExpectations = new HashSet<UserTaskExpectationBO>();
            UserTaskEvaluations = new HashSet<UserTaskEvaluationBO>();
            UserTaskComments = new HashSet<UserTaskCommentBO>();
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


        [ForeignKey("UserId")]
        public virtual UserBO User { get; set; }

        

        public virtual ICollection<UserTaskExpectationBO> UserTaskExpectations { get; set; }
        public virtual ICollection<UserTaskEvaluationBO> UserTaskEvaluations { get; set; }
        public virtual ICollection<UserTaskCommentBO> UserTaskComments { get; set; }
    }
}
