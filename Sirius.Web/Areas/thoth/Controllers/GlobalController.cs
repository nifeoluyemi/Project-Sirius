using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirius.Web.Areas.thoth.Models;
using Sirius.Data.BusinessObject;
using Sirius.Web.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Services.Manager;

namespace Sirius.Web.Areas.thoth.Controllers
{
    [Authorize(Roles = SiriusRoles.GA)]
    public class GlobalController : BaseController
    {
        public GlobalController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: thoth/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Organization()
        {
            return View(new OrganizationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Organization(OrganizationViewModel model)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    OrganizationBO organization = new OrganizationBO
                    {
                        Name = model.FullName,
                        ShortName = model.ShortName,
                        Status = Entity.Enums.Status.ACTIVE,
                        Audit = new Entity.Entities.Audit(CurrentUserId)
                    };
                    zeus.organizationManager.Add(organization);

                    return View();
                }
                return View();
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return View(model);
            }
        }
    }
}