using Microsoft.AspNet.Identity;
using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Web.Infrastructure.Attributes;
using Sirius.Web.Infrastructure.Constants;
using Sirius.Web.Helpers.IdentityHelpers;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Sirius.Services.Manager;
//using Sirius.Services.Manager;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Sirius.Web.Controllers
{
    [Authorize(Roles = SiriusRoles.MACHINE)]
    public class AdminController : BaseController
    {
        //IZeus zeus;
        public AdminController(IZeus _zeus)
            : base(_zeus)
        {

        }
        
        public ActionResult Privileges()
        {
            return View(new PrivilegeViewModel());
        }

        public ActionResult UsersAndRoles()
        {
            
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult UpdateUserRoles(string userId)
        {
            UserRoleViewModel model = new UserRoleViewModel();
            RoleBO GA = RoleManager.FindByName(SiriusRoles.GA);
            RoleBO Machine = RoleManager.FindByName(SiriusRoles.MACHINE);
            List<RoleBO> roles = RoleManager.Roles.ToList();
            roles.Remove(GA);
            roles.Remove(Machine);
            model.UserRoles = UserManager.GetRoles(userId);
            foreach (RoleBO role in roles)
            {
                SelectListItem item = new SelectListItem
                {
                    Selected = model.UserRoles.Contains(role.Name),
                    Text = role.Name,
                    Value = role.Name
                };
                model.RoleList.Add(item);
            }
            model.UserId = userId;
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserRoles(UserRoleViewModel model)
        {
            try
            {
                bool clearRoles = RemoveAllUserRoles(model.UserId);
                if (clearRoles)
                {
                    bool addToRoles = AddUserToRoles(model.UserId, model.UserRoles);
                    if (!addToRoles)
                        return Json(JsonResponse.Error("Please try again"));
                    return Json(JsonResponse.Success("User Roles Updated"));
                }
                else
                    return Json(JsonResponse.Error("An Error occured, Please try again"));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return Json(JsonResponse.Error("An Error occured, Please try again"));
            }
        }

        public ActionResult RemoveUser(string userId)
        {

            return Json(JsonResponse.Error("Error Deleting"));
        }

        //change to async
        private bool RemoveAllUserRoles(string userId)
        {
            IList<string> roles = UserManager.GetRoles(userId);
            if (roles.Count == 0 || roles == null)
                return true;
            foreach (string role in roles)
            {
                if (!UserManager.RemoveFromRole(userId, role).Succeeded)
                    return false;
            }
            return true;
        }

        private bool AddUserToRoles(string userId, IEnumerable<string> roles)
        {
            if (roles != null)
            {
                foreach (string role in roles)
                {
                    if (!UserManager.IsInRole(userId, role))
                    {
                        if (!UserManager.AddToRole(userId, role).Succeeded)
                            return false;
                    }
                }
            }
            return true;
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile.ContentLength == 0 || excelfile == null)
            {
                return View();
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string name = Path.GetFileName(excelfile.FileName);
                    string path = Server.MapPath("~/Content/" + name);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                    excelfile.SaveAs(path);

                    //List<StaffTableViewModel> StaffList = new List<StaffTableViewModel>();

                    //read from excel file...
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    for (int row = 7; row <= 44; row++)
                    {
                        //Change Rows and Column Details
                        StaffDetailBO staff = new StaffDetailBO();
                        staff.StaffID = ((Excel.Range)range.Cells[row, 1]).Text;
                        staff.FullName = ((Excel.Range)range.Cells[row, 2]).Text;
                        staff.Department = ((Excel.Range)range.Cells[row, 7]).Text;
                        staff.Email = ((Excel.Range)range.Cells[row, 10]).Text;
                        staff.Supervisor = ((Excel.Range)range.Cells[row, 14]).Text;
                        staff.JobDescription = ((Excel.Range)range.Cells[row, 13]).Text;
                        staff.Status = ((Excel.Range)range.Cells[row, 17]).Text;
                        staff.OrganizationID = CurrentOrganizationId;
                        //context.StaffTable.Add(staff);
                        zeus.staffManager.Add(staff);
                    }
                    //context.SaveChanges();
                    //ViewBag.StaffList = StaffList;
                    ViewBag.Success = "Import Successful";
                    return View();
                }
                else
                {
                    return View();
                }
            }
        }


    }
}