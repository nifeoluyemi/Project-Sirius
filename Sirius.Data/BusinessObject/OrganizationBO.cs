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
    [Table("Organization")]
    public class OrganizationBO : Organization
    {
        public OrganizationBO()
        {
            Users = new HashSet<UserBO>();
            PrivilegeRequests = new HashSet<PrivilegeRequestBO>();
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

        public virtual ICollection<UserBO> Users { get; set; }
        public virtual ICollection<PrivilegeRequestBO> PrivilegeRequests { get; set; }
    }
}
