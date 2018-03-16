using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sirius.Services.Manager;
using Sirius.Services.Wrappers;

namespace Sirius.Web.Controllers
{
    [Authorize(Roles = SiriusRoles.PMA)]
    public class PMController : BaseController
    {
        //IZeus zeus;
        public PMController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: PMAdmin
        public ActionResult Search()
        {
            
            return View();
        }

        //[OutputCache(Duration = 1200, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public PartialViewResult SearchUsers()
        {

            return PartialView();
            
        }

        
        [HttpPost]
        public async Task<ActionResult> AssignSupervisor(string userId)
        {
            try
            {
                bool isSupervisor = await UserManager.IsInRoleAsync(userId, SiriusRoles.SUPERVISOR);
                if(isSupervisor)
                    return Json(JsonResponse.Error("User is already a supervisor"));

                var result = await UserManager.AddToRoleAsync(userId, SiriusRoles.SUPERVISOR);
                return result.Succeeded ? Json(JsonResponse.Success("Succesfully added as Supervisor")) : Json(JsonResponse.Error("User cannot be added as supervisor, Please try again."));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return Json(JsonResponse.Error("Try Again"));
            }
        }

        public ActionResult AppraisalSettings()
        {

            return View();
        }

    }
}