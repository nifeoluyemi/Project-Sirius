using Sirius.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirius.Web.Models
{
    public class SettingsViewModel
    {

    }

    public class SettingsPartialViewModel
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string OrganizationName { get; set; }

        public string Active { get; set; }
    }

    public class AccountSettingsViewModel
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public string imageCode { get; set; }
    }

    public class PasswordSettingViewModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class PrivilegeSettingsViewModel
    {
        public bool HasSupervisorRequest { get; set; }
        public bool HasHODRequest { get; set; }
        public bool HasPMAdminRequest { get; set; }
        public bool HasITAdminRequest { get; set; }
    }

    public class RequestListViewModel
    {
        public IEnumerable<PrivilegeRequestDTO> PendingRequests { get; set; }
        public IEnumerable<PrivilegeRequestDTO> DeniedRequests { get; set; }
    }
}