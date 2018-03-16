using Sirius.Services.Manager;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirius.Web.Controllers
{
    [Authorize]
    public class OrganizationController : BaseController
    {
        //IZeus zeus;
        public OrganizationController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }

        [Route("support")]
        public ActionResult Support()
        {
            return View(new SupportViewModel());
        }

        public ActionResult Support(SupportViewModel model)
        {
            UserManager.EmailService.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage
            {
                Subject = model.Subject,
                Body = model.Message,
                Destination = "geekcampstudios@outlook.com"
            });
            return View();
        }
    }
}