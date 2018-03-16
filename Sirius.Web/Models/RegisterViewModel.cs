using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Sirius.Web.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            this.StaffStatuses = new List<SelectListItem>();
            this.Departments = new List<SelectListItem>();
        }


        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string StaffID { get; set; }

        public Guid StaffStatusId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid OrganizationId { get; set; }

        public string JobDescription { get; set; }

        public string PhoneNumber { get; set; }

        public Sirius.Entity.Enums.Gender Gender { get; set; }

        public string DateOfBirth { get; set; }

        public List<SelectListItem> StaffStatuses { get; set; }
        public List<SelectListItem> Departments { get; set; }

        public string imageCode { get; set; }
    }

    public class SignUpViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Your first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your surame is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public string OrganizationName { get; set; }
        public Guid OrganizationId { get; set; }
    }

    public class AccountSetupViewModel
    {
        public AccountSetupViewModel()
        {
            StaffStatuses = new List<SelectListItem>();
            Departments = new List<SelectListItem>();
        }
        public string UserFirstname { get; set; }
        public string OrganizationName { get; set; }
        public Guid OrganizationId { get; set; }
        [Required]
        public string StaffId { get; set; }
        [Required(ErrorMessage = "You need to select a status")]
        public Guid StaffStatusId { get; set; }
        [Required(ErrorMessage = "You need to select a department")]
        public Guid DepartmentId { get; set; }
        public string JobDescription { get; set; }
        public IList<SelectListItem> StaffStatuses { get; set; }
        public IList<SelectListItem> Departments { get; set; }
    }
}