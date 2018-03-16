using Sirius.Data.IdentityServices.Managers;
using Sirius.Data.BusinessObject;
using Sirius.Web.Helpers.IdentityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Sirius.Services.Manager;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.IO;
using ImageResizer;
using Sirius.Entity.Enums;
using System.Web.UI;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Services.Wrappers;

namespace Sirius.Web.Controllers
{
    public class BaseController : Controller
    {
        private SiriusSignInManager _signInManager;
        private SiriusUserManager _userManager;
        private SiriusRoleManager _roleManager;
        public IZeus zeus;

        public BaseController(IZeus _zeus)
        {
            zeus = _zeus;
        }

        public BaseController(SiriusUserManager userManager, SiriusSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public BaseController(SiriusUserManager userManager, SiriusSignInManager signInManager, SiriusRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public SiriusSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<SiriusSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public SiriusUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<SiriusUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public SiriusRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<SiriusRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //public Zeus Zeus 
        //{
        //    get
        //    {
        //        return zeus ?? new Zeus();
        //    }
        //    private set
        //    {
        //        zeus = value;
        //    }
        //}

        public string CurrentUserId
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        public Guid CurrentOrganizationId
        {
            get
            {
                return Guid.Parse(User.Identity.GetUserOrganizationId());
            }
        }


        public void LogError(Exception ex)
        {
            ErrorBO error = new ErrorBO();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            error.URLAccessed = Request.RawUrl;
            error.IPAddress = Request.UserHostAddress;
            error.DateCreated = DateTime.UtcNow;
            error.Audit = new Entity.Entities.Audit();

            //AddError
        }

        public void LogError(Exception ex, string currentUserId)
        {
            ErrorBO error = new ErrorBO();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            error.URLAccessed = Request.RawUrl;
            error.IPAddress = Request.UserHostAddress;
            error.DateCreated = DateTime.UtcNow;
            error.Audit = new Entity.Entities.Audit(currentUserId);

            //AddError
        }

        public void LogUserLogin(string userId)
        {
            try
            {
                UserAccountLoginBO userlogin = new UserAccountLoginBO();
                userlogin.UserId = userId;
                userlogin.LoginDate = DateTime.UtcNow;
                userlogin.IPAddress = Request.UserHostAddress;
                userlogin.ComputerName = System.Net.Dns.GetHostName();
                userlogin.Audit = new Entity.Entities.Audit(userId);

                zeus.staffManager.Add(userlogin);
            }
            catch (Exception ex)
            {
                LogError(ex, userId);
            }
        }

        public async Task LogUserLoginAsync(string userId)
        {
            try
            {
                UserAccountLoginBO userlogin = new UserAccountLoginBO();
                userlogin.UserId = userId;
                userlogin.LoginDate = DateTime.UtcNow;
                userlogin.IPAddress = Request.UserHostAddress;
                userlogin.ComputerName = Request.UserHostName;
                userlogin.Audit = new Entity.Entities.Audit(userId);

                await Task.Run(() => zeus.staffManager.Add(userlogin));
            }
            catch (Exception ex)
            {
                LogError(ex, userId);
            }
        }

        public FileContentResult GetEmailHeaderImage()
        {
            string imagePath = Server.MapPath("~/EmailTemplates/images/head1.png");
            byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
            return File(imageData, "image/png");
        }

        [OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public async Task<FileContentResult> GetUserAvatar(string username)
        {
            string defaultPath = Server.MapPath("~/Content/image/default-avatar.png");
            byte[] imageData = System.IO.File.ReadAllBytes(defaultPath);
            if (string.IsNullOrEmpty(username))
                return File(imageData, "image/png");

            UserBO user = await Task.Run(()=> UserManager.Users.Where(u => u.UserName == username).Select(u => new UserWrapper { ImageContent = u.ImageContent, ImageMimeType = u.ImageMimeType }).FirstOrDefault());
            return (user != null && user.ImageContent != null && !string.IsNullOrWhiteSpace(user.ImageMimeType)) ? File(user.ImageContent, user.ImageMimeType) : File(imageData, "image/png");
        }

        [OutputCache(Duration = 3600, VaryByParam = "*", Location = OutputCacheLocation.Client)]
        public async Task<FileContentResult> GetUserIdAvatar(string userId)
        {
            string defaultPath = Server.MapPath("~/Content/image/default-avatar.png");
            byte[] imageData = System.IO.File.ReadAllBytes(defaultPath);
            if (string.IsNullOrEmpty(userId))
                return File(imageData, "image/png");

            UserBO user = await Task.Run(()=> UserManager.Users.Where(u => u.Id == userId).Select(u => new UserWrapper { ImageContent = u.ImageContent, ImageMimeType = u.ImageMimeType }).FirstOrDefault());
            return (user != null && user.ImageContent != null && !string.IsNullOrWhiteSpace(user.ImageMimeType)) ? File(user.ImageContent, user.ImageMimeType) : File(imageData, "image/png");
        }

        public async Task<FileContentResult> GetResizedUserIdAvatar(string userId, int width, int height)
        {
            string defaultPath = Server.MapPath("~/Content/image/default-avatar160.png");
            byte[] imageData = System.IO.File.ReadAllBytes(defaultPath);

            UserBO user = await UserManager.FindByIdAsync(userId);

            if (user != null && user.ImageContent != null && !string.IsNullOrWhiteSpace(user.ImageMimeType))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (MemoryStream inStream = new MemoryStream(user.ImageContent))
                    {
                        ResizeSettings settings = new ResizeSettings { MaxWidth = width, MaxHeight = height };
                        ImageResizer.ImageBuilder.Current.Build(inStream, outStream, settings);
                        byte[] outBytes = outStream.ToArray();
                        return File(outBytes, user.ImageMimeType);
                    }
                }
            }
            else
            {
                return File(imageData, "image/png");
            }
        }

        
        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //Renew appraisal period method
        //.....

        // Add Notification Method.....
        public void AddNotification(NotificationType notificationType, string senderId, string recipientId, string notificationUrl)
        {
            try
            {
                NotificationBO notification = new NotificationBO();
                string senderName = "";// senderId == recipientId ? "You" : zeus.staffManager.GetStaffName(senderId);
                string message = null;

                switch (notificationType)
                {
                    case NotificationType.NewTask:
                        message = senderName + " created a New Task.";
                        break;
                    case NotificationType.NewTaskEvaluation:
                        message = senderName + " evaluated one of your Tasks.";
                        break;
                    case NotificationType.Nomination:
                        message = "You have a New Nomination.";
                        break;
                    case NotificationType.NewTaskComment:
                        message = senderName + " comented on one of your Tasks.";
                        break;
                    case NotificationType.TaskAccepted:
                        message = "A Task of yours has been approved.";
                        break;
                    case NotificationType.TaskDeclined:
                        message = "A Task of yours has been declined.";
                        break;
                    case NotificationType.SupervisorRequest:
                        message = senderName + " sent you a Supervisor Request.";
                        break;
                    case NotificationType.SupervisorAccepted:
                        message = senderName + " accepted your request.";
                        break;
                    case NotificationType.SupervisorDeclined:
                        message = senderName + " declined your request.";
                        break;
                    case NotificationType.SupervisorAppraisalApproval:
                        message = "Your Supervisor has approved your appraisal.";
                        break;
                    case NotificationType.HodAppraisalApproval:
                        message = "Your HOD has approved your appraisal.";
                        break;
                    case NotificationType.NewCompetencyEvaluation:
                        message = senderName + " evaluated one of your job competencies.";
                        break;
                    case NotificationType.NewCompetencyComment:
                        message = senderName + " comented on one of your job competencies. ";
                        break;
                    case NotificationType.AppraisalContest:
                        message = senderName + " contested their appraisal result. ";
                        break;
                    default:
                        message = "";
                        break;
                }

                notification.Message = message;
                notification.NotificationState = NotificationState.Unread;
                notification.NotificationType = notificationType;
                notification.SenderId = senderId;
                notification.RecipientId = recipientId;
                notification.URL = notificationUrl;
                notification.Audit = new Entity.Entities.Audit();

                zeus.notificationManager.Add(notification);

            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
            }
        }
        public async Task AddNotificationAsync(NotificationType notificationType, string senderId, string recipientId, string notificationUrl)
        {
            try
            {
                NotificationBO notification = new NotificationBO();
                string senderName = "";// zeus.staffManager.GetStaffName(senderId);
                string message = null;

                switch (notificationType)
                {
                    case NotificationType.NewTask:
                        message = senderName + " just created a New Task.";
                        break;
                    case NotificationType.NewTaskEvaluation:
                        message = senderName + " just Evaluated one of your Tasks.";
                        break;
                    case NotificationType.Nomination:
                        message = "You have a New Nomination.";
                        break;
                    case NotificationType.NewTaskComment:
                        message = senderName + " just comented on one of your Tasks.";
                        break;
                    case NotificationType.TaskAccepted:
                        message = "A Task of yours has been approved.";
                        break;
                    case NotificationType.TaskDeclined:
                        message = "A Task of yours has been declined.";
                        break;
                    case NotificationType.SupervisorRequest:
                        message = senderName + " sent you a Supervisor Request.";
                        break;
                    case NotificationType.SupervisorAccepted:
                        message = senderName + " Accepted your request.";
                        break;
                    case NotificationType.SupervisorDeclined:
                        message = senderName + " Declined your request.";
                        break;
                    case NotificationType.SupervisorAppraisalApproval:
                        message = "Your Supervisor has approved your appraisal.";
                        break;
                    case NotificationType.HodAppraisalApproval:
                        message = "Your HOD has approved your appraisal.";
                        break;
                    case NotificationType.NewCompetencyEvaluation:
                        message = senderName + " just Evaluated one of your job competencies.";
                        break;
                    case NotificationType.NewCompetencyComment:
                        message = senderName + " just comented on one of your job competencies. ";
                        break;
                    case NotificationType.AppraisalContest:
                        message = senderName + " contested their appraisal result. ";
                        break;
                    default:
                        message = "";
                        break;
                }

                notification.Message = message;
                notification.NotificationState = NotificationState.Unread;
                notification.NotificationType = notificationType;
                notification.SenderId = senderId;
                notification.RecipientId = recipientId;
                notification.URL = notificationUrl;
                notification.ReadDate = DateTime.UtcNow;
                notification.Audit = new Entity.Entities.Audit(senderId);


                await zeus.notificationManager.AddAsync(notification);

            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}