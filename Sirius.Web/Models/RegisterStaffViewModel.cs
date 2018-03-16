using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirius.Web.Models
{
    public class RegisterStaffViewModel
    {
        public RegisterStaffViewModel()
        {
            StaffStatuses = new List<SelectListItem>();
            Departments = new List<SelectListItem>();
        }
        public string StaffID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string JobDescription { get; set; }
        public Guid OrganizationID { get; set; }

        [Required(ErrorMessage = "You need to select a status")]
        public Guid StaffStatusId { get; set; }
        [Required(ErrorMessage = "You need to select a department")]
        public Guid DepartmentId { get; set; }
        public IList<SelectListItem> StaffStatuses { get; set; }
        public IList<SelectListItem> Departments { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}