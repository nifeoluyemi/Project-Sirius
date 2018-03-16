using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Helpers.IdentityHelpers;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sirius.Services.Manager;

namespace Sirius.Web.Controllers
{
    [Authorize(Roles = SiriusRoles.USER)]
    public class SettingsController : BaseController
    {
        //IZeus zeus;
        public SettingsController(IZeus _zeus)
            : base(_zeus)
        {

        }
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public ActionResult SettingsPartial(string link)
        {
            UserBO user = UserManager.FindById(CurrentUserId);
            SettingsPartialViewModel model = new SettingsPartialViewModel
            {
                UserId = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                OrganizationName = "",
                Active = link
            };
            return PartialView(model);
        }

        public async Task<ActionResult> Account()
        {
            UserBO user = await UserManager.FindByIdAsync(CurrentUserId);
            AccountSettingsViewModel model = new AccountSettingsViewModel
            {
                UserId = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Middlename = user.MiddleName,
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Account(AccountSettingsViewModel model, HttpPostedFileBase Image)
        {
            try
            {
                UserBO user = await UserManager.FindByIdAsync(CurrentUserId);
                user.FirstName = model.Firstname;
                user.MiddleName = model.Middlename;
                user.LastName = model.Lastname;
                user.Email = model.Email;

                if (Image != null)
                {
                    string ImageCode = model.imageCode;
                    var base64Data = Regex.Match(ImageCode, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                    byte[] binData = Convert.FromBase64String(base64Data);

                    user.ImageMimeType = "image/png";
                    int imgLength = (int)binData.Length;
                    user.ImageContent = new byte[imgLength];

                    using (MemoryStream stream = new MemoryStream(binData))
                    {
                        stream.Read(user.ImageContent, 0, imgLength);
                    };
                }

                await UserManager.UpdateAsync(user);
                return RedirectToAction("account", "settings");
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return View("Error");
            }
        }


        public ActionResult Password()
        {

            return View(new PasswordSettingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Password(PasswordSettingViewModel model)
        {
            try
            {
                var result = await UserManager.ChangePasswordAsync(CurrentUserId, model.CurrentPassword, model.NewPassword);
                return result.Succeeded ? Json(JsonResponse.Success("You have successfully changed your password")) : Json(JsonResponse.Error("Error changing your password, please try again."));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return Json(JsonResponse.Error("An Error occurred while changing your password, please try again."));
            }
        }

        
        public ActionResult Privilege()
        {
            PrivilegeSettingsViewModel model = new PrivilegeSettingsViewModel
            {
                
            };
            return View(model);
        }

        public ActionResult RequestList()
        {
            
            return PartialView();
        }
    }
}