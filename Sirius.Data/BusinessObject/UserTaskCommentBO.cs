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
    [Table("UserTaskComment")]
    public class UserTaskCommentBO : UserTaskComment
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

        public override string CommenterId
        {
            get
            {
                return base.CommenterId;
            }
            set
            {
                base.CommenterId = value;
            }
        }

        [ForeignKey("CommenterId")]
        public virtual UserBO Commenter { get; set; }

        [ForeignKey("UserTaskId")]
        public virtual UserTaskBO UserTask { get; set; }
    }
}
