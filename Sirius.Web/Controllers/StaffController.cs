using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Services.DTO;
using Sirius.Services.Manager;
using Sirius.Web.Infrastructure.Attributes;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sirius.Services.Wrappers;

namespace Sirius.Web.Controllers
{
    [Authorize(Roles = SiriusRoles.USER)]
    public class StaffController : BaseController
    {
        //IZeus zeus;
        public StaffController(IZeus _zeus)
            : base(_zeus)
        {

        }

        // GET: Staff
        [Route("dashboard")]
        //[OutputCache(Duration = 600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            UserBO currentUser = UserManager.FindById(CurrentUserId);
            
            return View();
        }

        [ChildActionOnly]
        public ActionResult UserDimension()
        {

            return PartialView();
        }

        
        [ChildActionOnly]
        public ActionResult UserTask()
        {

            return PartialView();
        }


        public ActionResult Setup()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setup(AccountSetupViewModel viewModel)
        {
            try
            {
                 return View();
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return View("error");
            }
        }

        [AjaxRequestOnly]
        //[OutputCache(Duration = 600, Location = OutputCacheLocation.Client, NoStore = true)]
        public async Task<ActionResult> GetNotifications()
        {
            IEnumerable<NotificationBO> allnotifications = await zeus.notificationManager.GetNotificationAsync(CurrentUserId).ConfigureAwait(false);
            int count = allnotifications.Count();
            allnotifications = allnotifications.OrderByDescending(n => n.Audit.CreatedDate);
            IEnumerable<NotificationBO> notifications = count > 30 ? allnotifications.Take(30) : allnotifications;
            return PartialView(NotificationDTO.Map(notifications, zeus));
        }


    }
}