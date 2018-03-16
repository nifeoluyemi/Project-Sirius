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
    [Table("Organization")]
    public class OrganizationBO : Organization
    {
        public OrganizationBO()
        {
            this.Departments = new HashSet<DepartmentBO>();
            this.Users = new HashSet<UserBO>();
            this.AppraisalPeriods = new HashSet<AppraisalPeriodBO>();
            this.AppraisalDimensions = new HashSet<AppraisalDimensionBO>();
            this.OrganizationStaffStatus = new HashSet<OrganizationStaffStatusBO>();
            this.AppraisalRecommendations = new HashSet<AppraisalRecommendationBO>();
            this.OrganizationObjectives = new HashSet<OrganizationObjectiveBO>();
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

        public virtual ICollection<DepartmentBO> Departments { get; set; }
        public virtual ICollection<UserBO> Users { get; set; }
        public virtual ICollection<AppraisalPeriodBO> AppraisalPeriods { get; set; }
        public virtual ICollection<AppraisalDimensionBO> AppraisalDimensions { get; set; }
        public virtual ICollection<OrganizationStaffStatusBO> OrganizationStaffStatus { get; set; }
        public virtual ICollection<AppraisalRecommendationBO> AppraisalRecommendations { get; set; }
        public virtual ICollection<OrganizationObjectiveBO> OrganizationObjectives { get; set; }
    }
}
