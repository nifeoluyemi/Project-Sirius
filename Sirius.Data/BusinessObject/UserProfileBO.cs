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
    [Table("UserProfile")]
    public class UserProfileBO : UserProfile
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

        public override Guid UserTimeZoneId
        {
            get
            {
                return base.UserTimeZoneId;
            }
            set
            {
                base.UserTimeZoneId = value;
            }
        }
    }
}
