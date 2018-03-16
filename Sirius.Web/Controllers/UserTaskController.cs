using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Services.Manager;
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
using System.Data.Entity;

namespace Sirius.Web.Controllers
{
    public class UserTaskController : BaseController
    {
        //IZeus zeus;
        public UserTaskController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: UserTask
        [Route("tasks/{username?}")]
        //[OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public ActionResult Index(string username = null)
        {
            //string userId = string.IsNullOrWhiteSpace(username) ? CurrentUserId : (zeus.staffManager.GetUserId(username, CurrentOrganizationId) ?? CurrentUserId);
          
            return View();
        }

        
        [Route("task/{userTaskId}")]
        public ActionResult TaskDetail(Guid userTaskId)
        {
            return View(new UserTaskDetailViewModel { UserTaskId = userTaskId });
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 2400, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public ActionResult EditTask(Guid userTaskId)
        {
            UserTaskBO userTask = zeus.evaluationManager.GetUserTaskById(userTaskId);

            EditTaskViewModel model = new EditTaskViewModel
            {
                UserTaskId = userTask.Id,
                Title = userTask.Title,
                Description = userTask.Description
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask(EditTaskViewModel model)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(model.Title))
                    return Json(JsonResponse.Error("The title field cannot be empty."));
                UserTaskBO userTask = zeus.evaluationManager.GetUserTaskById(model.UserTaskId);

                userTask.Title = model.Title;
                userTask.Description = model.Description;

                zeus.evaluationManager.Update(userTask);
                return Json(JsonResponse.Success("Your Task has been succesfully Updated."));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return Json(JsonResponse.Error("An Error occured while editing this task, please try again"));
            }
        }

    }
}