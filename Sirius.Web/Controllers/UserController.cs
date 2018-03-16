using Sirius.Data.IdentityServices.Managers;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using System.Threading.Tasks;
using Sirius.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Sirius.Web.Infrastructure.Constants;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using Sirius.Web.Infrastructure.Attributes;
using System.Web.UI;

namespace Sirius.Web.Controllers
{
    //[RequireHttps]
    public class UserController : BaseController
    {
        //IZeus zeus;
        public UserController(IZeus _zeus)
            : base(_zeus)
        {

        }

        [Route("org/{returnUrl}")]
        public ActionResult Index(string returnUrl)
        {
            
            //if (Request.IsAuthenticated)
            //    return Redirect("~/dashboard");
            //check user roles
            //check if it's sigin or reg
            ViewBag.ReturnURL = returnUrl;
            string ReturnURL = returnUrl;
            return View(model: ReturnURL);
        }

        
        //disallow from viewing link that's not your org, or people not in your org
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
                return Redirect("~/dashboard");
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //UserBO user = await UserManager.FindByNameAsync(model.Email);
                //if (user == null)
                //{
                //    //Check Staff Database
                //    StaffDetailBO staff = zeus.staffManager.GetStaffDetailByEmail(model.Email);
                //    if (staff != null)
                //    {
                //        //Redirect to setup page...
                //        return RedirectToAction("registerstaff", new { email = model.Email }); //View("RegisterStaff", staffmodel);
                //    }
                //}
                //else
                //{
                var signinResult = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: true);
                if (signinResult == SignInStatus.Success)
                {
                    UserBO user = await UserManager.FindByNameAsync(model.Email);
                    if (user.Audit.RecordState == Entity.Enums.RecordStateType.InActive)
                    {
                        ModelState.AddModelError("", "Invalid login credentials");
                        return View(model);
                    }
                    if (!user.EmailConfirmed)
                    {
                        AuthenticationManager.SignOut();
                        return Redirect("~/confirmation/required");
                    }
                    await LogUserLoginAsync(user.Id);
                    IEnumerable<string> roles = await UserManager.GetRolesAsync(user.Id);
                    if (roles.Contains(SiriusRoles.USER))
                        return Redirect("~/dashboard");
                    if (roles.Contains(SiriusRoles.MACHINE))
                        return RedirectToAction("department", "admin");
                    if (roles.Contains(SiriusRoles.GA))
                        return RedirectToAction("Organization", "Global", new { area = "thoth" });
                    else
                    {
                        AuthenticationManager.SignOut();
                        return RedirectToAction("login", "user");
                    }
                }
                if (signinResult == SignInStatus.Failure)
                {
                    ModelState.AddModelError("", "Invalid login credentials");
                    return View(model);
                }
                if (signinResult == SignInStatus.LockedOut)
                {
                    return View("Lockout");
                }
                if (signinResult == SignInStatus.RequiresVerification)
                {
                    return RedirectToAction("SendCode", new { RememberMe = model.RememberMe });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View(model);
                }
            //}
            }
            return View(model);
        }

        [Route("user/register")]
        public ActionResult Register()
        {
            return View();
        }
        
        [AjaxRequestOnly]
        public ActionResult SignUp(string orgName)
        {
            //check if staff id exist in view
            SignUpViewModel model = new SignUpViewModel
            {
                OrganizationName = orgName,
                OrganizationId = zeus.organizationManager.GetOrganizationByShortName(orgName).Id
            };
            return PartialView(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string[] emailParts = model.Email.Split(new[] { '@' });
                    UserBO newUser = new UserBO
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        StaffUserName = emailParts[0],
                        UserName = model.Email,
                        OrganizationId = model.OrganizationId,
                        LockoutEnabled = true,
                        Audit = new Entity.Entities.Audit(),
                        EmailConfirmed = true //remove
                    };

                    IdentityResult result = await UserManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        //remove this
                        var roleResult = await UserManager.AddToRoleAsync(newUser.Id, SiriusRoles.USER);
                        if (roleResult.Succeeded)
                        {
                            await SignInManager.SignInAsync(newUser, false, false);
                            return Json(JsonResponse.RedirectTo("", Url.Action("setup", "staff")));
                        }
                        //remove

                        ////send verification email
                        //string code = await UserManager.GenerateEmailConfirmationTokenAsync(newUser.Id);
                        //string callbackUrl = Url.Action("confirm", "user", new { userId = newUser.Id, code = code }, protocol: Request.Url.Scheme);

                        //string imageUrl = Url.Action("GetEmailHeaderImage", "Base");
                        ////string route = "../" + orgName + "/confirmation/" + user.Id + "/" + code; /EmailTemplates/images/head1.png

                        //string emailBody = await CreateEmailBodyAsync("../EmailTemplates/AccountConfirmation.html", newUser.Email, newUser.FirstName, callbackUrl, imageUrl);
                        //await UserManager.SendEmailAsync(newUser.Id, "SiriusPM Account Confimation", emailBody);
                        
                        ////user/confirmationsent
                        //string url = "~/confirmationsent";
                        //return Json(JsonResponse.RedirectTo("", url));
                    }
                    else
                    {
                        return PartialView(model);
                    }
                }
                return PartialView(model);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return PartialView(model);
            }
        }

        
        [Route("locked")]
        public ActionResult Locked() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("login", "user");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {

            return RedirectToAction("");
        }

        [Route("confirmation/required")]
        public ActionResult ConfirmationRequired()
        {
            return View();
        }

        [Route("confirmationsent")]
        public ActionResult ConfirmationSent()
        {
            return View();
        }

        
        public async Task<ActionResult> Confirm(string userId, string code)
        {
            if (userId == null || code == null)
                return RedirectToAction("login", "user");

            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                UserBO user = await UserManager.FindByIdAsync(userId);
                if (UserManager.IsInRole(userId, SiriusRoles.USER))
                {
                    await SignInManager.SignInAsync(user, false, false);
                    return RedirectToAction("setup", "staff");//redirect to dashboard
                }

                var roleResult = await UserManager.AddToRoleAsync(userId, SiriusRoles.USER);
                if(roleResult.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false, false);
                    return RedirectToAction("setup", "staff");
                }
                
                return View("Error");
            }
            else
            {
                return View("Error");
            }
        }

        
        [Route("sendconfirmation")]
        public ActionResult SendConfirmation()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SendConfirmationToEmail(string email)
        {
            //check if it's org email
            if (RegexExtension.IsValidEmail(email))
            {
                UserBO user = await UserManager.FindByEmailAsync(email);
                if (user == null)
                    return Json(JsonResponse.Success("Please Check your email to Reset your Password"));
                if(user.EmailConfirmed == true)
                    return Json(JsonResponse.Success("Your Email has been Confirmed"));

                try
                {
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    string callbackUrl = Url.Action("confirm", "account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    string emailBody = await CreateEmailBodyAsync("../EmailTemplates/AccountConfirmation.html", user.Email, user.FirstName, callbackUrl, "");

                    await UserManager.SendEmailAsync(user.Id, "SiriusPM Account Confimation", emailBody);
                    return Json(JsonResponse.Success("Please Check your email to Reset your Password"));
                }
                catch(Exception ex)
                {
                    LogError(ex, string.Empty);
                    return Json(JsonResponse.Error("Unsuccesfull"));
                }
            }
            return Json(JsonResponse.Error("Enter a valid Email Address"));
        }

        [Route("recover")]
        public ActionResult ForgotPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SendPasswordResetEmail(string email)
        {
            if (RegexExtension.IsValidEmail(email))
            {
                UserBO user = await UserManager.FindByEmailAsync(email);
                if (user == null)
                    return Json(JsonResponse.Success("We've sent you an email to enable you reset your password. Please Check your email for instructions."));

                try
                {
                    string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                    var callbackUrl = Url.RouteUrl("Organization_PasswordReset",
                        new { email = user.Email, code = code }, protocol: Request.Url.Scheme);
                    //string route = "../reset/" + user.UserName + "/" + code; ;

                    string imageUrl = Url.Action("images", "EmailTemplates") + "/head1.png";

                    string emailBody = await CreateEmailBodyAsync("../EmailTemplates/AccountConfirmation.html", user.Email, user.FirstName, callbackUrl, imageUrl);
                    await UserManager.SendEmailAsync(user.Id, "SiriusPM Account Confimation", emailBody);
                    return Json(JsonResponse.Success("We've sent you an email to enable you reset your password. Please Check your email for instructions."));
                }
                catch(Exception ex)
                {
                    LogError(ex, string.Empty);
                    return Json(JsonResponse.Error("Something went wrong, please try again."));
                }
            }
            return Json(JsonResponse.Error("Enter a valid Email Address"));
        }

        [Route("reset/{email}/{code}")]
        public ActionResult ResetPassword(string email, string code)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(code))
                return Redirect("~/org/signin");

            UserBO user = UserManager.FindByName(email);
            if(user == null)
                return Redirect("~/org/signin");

            ResetPasswordViewModel model = new ResetPasswordViewModel 
            { 
                Code = code,
                Email = email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendResetPassword(ResetPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                UserBO user = await UserManager.FindByNameAsync(model.Email);
                IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.NewPassword);
                if (result.Succeeded)
                {
                    //sign in async
                    await SignInManager.SignInAsync(user, false, false);
                    return Redirect("~/dashboard");
                }
            }
            return View();
        }

        [HttpPost]
        public JsonResult Invite(string email)
        {
            try
            {

                return Json(JsonResponse.Success("Your successfully accepted this staff."));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return Json(JsonResponse.Error("Error accepting staff, please try again."));
            }
        }


        private async Task<string> CreateEmailBodyAsync(string path, string email, string firstname, string url, string imageUrl)
        {
            string emailBody = string.Empty;

            using(StreamReader reader = new StreamReader(Server.MapPath(path)))
            {
                emailBody = await reader.ReadToEndAsync();
            }

            emailBody = emailBody.Replace("{email}", email);
            emailBody = emailBody.Replace("{Firstname}", firstname);
            emailBody = emailBody.Replace("{url}", url);
            emailBody = emailBody.Replace("{imageUrl}", imageUrl);

            return emailBody;
        }

    }
}