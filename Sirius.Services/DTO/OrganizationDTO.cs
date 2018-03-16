using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.DTO
{
    public class OrganizationDTO
    {
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }

        public byte[] LogoImageContent { get; set; }
        public string LogoImageMimeType { get; set; }
        
        //public IEnumerable<UserDTO> UsersInOrganization { get; set; }
        public int StaffCount { get; set; }

        //public IEnumerable<DepartmentDTO> DepartmentsInOrganization { get; set; }
        public int DepartmentCount { get; set; }

        //public IEnumerable<OrganizationObjectiveDTO> OrganizationObjectives { get; set; }
        public int RemainingDaysInCurrentAppraisalPeriod { get; set; }

        public OrganizationDTO Map(OrganizationBO organization, IZeus zeus)
        {
            OrganizationDTO self = this;

            self.OrganizationId = organization.Id;
            self.OrganizationName = organization.Name;
            self.OrganizationShortName = organization.ShortName;

            self.LogoImageContent = organization.OrganizationLogo;
            self.LogoImageMimeType = organization.ImageMimeType;
            //Guid appraisalPeriodId = zeus.organizationManager.GetAppraisalPeriodId(DateTime.UtcNow, organization.Id);

            //self.RemainingDaysInCurrentAppraisalPeriod = zeus.organizationManager.GetDaysRemainingInAppraisalPeriod(DateTime.UtcNow, appraisalPeriodId);

            return self;
        }
    }
}
