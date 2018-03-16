using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using Sirius.Services.Wrappers;
using Sirius.Services.DTO;

namespace Sirius.Web.RESTful
{
    public class UserApiController : BaseApiController
    {
        public UserApiController(IZeus _zeus)
            : base(_zeus)
        {

        }

        

        //[Authorize]
        public async Task<IHttpActionResult> GetUserInfo(string userId)
        {
            try
            {
                UserDTO user = await Task.Run(()=> UserManager.Users.Where(u => u.Id == userId)
                    .Select(u => new UserDTO { UserId = u.Id, Username = u.StaffUserName, FirstName = u.FirstName, LastName = u.LastName, OrganizationId = u.OrganizationId })
                    .FirstOrDefault());
                return Ok(user);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
