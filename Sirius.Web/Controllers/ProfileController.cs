using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Models;
using System.Web.UI;
using Sirius.Services.Manager;


namespace Sirius.Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        //IZeus zeus;
        public ProfileController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: Profile
        [Route("profile")]
        //[OutputCache(Duration = 2400, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            UserBO user = UserManager.FindById(CurrentUserId);

            UserDTO userInfo = UserDTO.Map(user, zeus);

            
            return View(userInfo);
        }

        [ChildActionOnly]
        public ActionResult TeamMembers(string supervisorid)
        {
            return PartialView();
        }
    }
}