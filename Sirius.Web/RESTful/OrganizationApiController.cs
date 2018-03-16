using Sirius.Data.BusinessObject;
using Sirius.Services.DTO;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace Sirius.Web.RESTful
{
    public class OrganizationApiController : BaseApiController
    {
        public OrganizationApiController(IZeus _zeus)
            : base(_zeus)
        {

        }
        //Get all organizations
        //public async Task<IEnumerable<OrganizationDTO>> Get()
        //{
        //    List<OrganizationDTO> organizations = new List<OrganizationDTO>();
        //    IEnumerable<OrganizationBO> orgs = await zeus.organizationManager.OrganizationsAsync();
        //    foreach (OrganizationBO org in orgs)
        //    {
        //        OrganizationDTO organization = new OrganizationDTO();
        //        organization = organization.Map(org, zeus);
        //        organizations.Add(organization);
        //    }
        //    return organizations.AsEnumerable();
        //}

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public bool OrganizationExist(string shortname)
        {
            try
            {
                return true; // await zeus.organizationManager.CheckIfOrganizationShortNameExistsAsync(shortname);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public bool ValidOrganizationEmail(Guid orgId, string email)
        {
            try
            {
                return true;// await zeus.staffManager.IsValidEmailForOrganizationAsync(orgId, email);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }
    }
}
