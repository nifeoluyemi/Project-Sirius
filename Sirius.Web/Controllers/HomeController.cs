using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirius.Services.Manager;

namespace Sirius.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IZeus _zeus)
            : base(_zeus)
        {

        }

        [Authorize]
        public ActionResult Index()
        {
            return View("~/App/layout/layout.cshtml");
        }

    }
}