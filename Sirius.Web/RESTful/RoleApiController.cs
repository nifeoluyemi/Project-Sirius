using Sirius.Services.Manager;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sirius.Web.RESTful
{
    [Authorize]
    public class RoleApiController : BaseApiController
    {
        public RoleApiController(IZeus _zeus)
            : base(_zeus)
        {

        }

        public IHttpActionResult GetUserRoles()
        {
            try
            {
                RolesViewModel result = new RolesViewModel
                {
                    IsStaff = User.IsInRole(SiriusRoles.USER),
                    IsSupervisor = User.IsInRole(SiriusRoles.SUPERVISOR),
                    IsHOD = User.IsInRole(SiriusRoles.HOD),
                    IsPMAdmin = User.IsInRole(SiriusRoles.PMA),
                    IsITAdmin = User.IsInRole(SiriusRoles.ITA),
                    IsMachine = User.IsInRole(SiriusRoles.MACHINE),
                    IsGlobalAdmin = User.IsInRole(SiriusRoles.GA)
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
