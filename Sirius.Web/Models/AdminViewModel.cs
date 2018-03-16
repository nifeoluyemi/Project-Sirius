using Sirius.Entity.Enums;
using Sirius.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirius.Web.Models
{
    public class AdminViewModel
    {
    }

    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            AddModel = new List<AddDepartmentViewModel>();
        }

        public IList<AddDepartmentViewModel> AddModel { get; set; }
    }

    public class AddDepartmentViewModel
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Description { get; set; }
    }

    public class StatusViewModel
    {
        public StatusViewModel()
        {
            AddStatus = new List<AddStatusViewModel>();
        }

        public IList<AddStatusViewModel> AddStatus { get; set; }
    }

    public class AddStatusViewModel
    {
        public Guid StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusShortname { get; set; }
    }

    public class PrivilegeViewModel
    {

    }

    //user and roles viewmodel
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            RoleList = new List<SelectListItem>();
        }

        public string UserId { get; set; }
        public IList<SelectListItem> RoleList { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }

    public class AppraisalSettingsViewModel
    {
        public int DaysRemaining { get; set; }
        public bool IsValidAppraisalCycle { get; set; }
        public bool IsUpdate { get; set; }
        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public bool IsAppraisalPeriod { get; set; }
        public string RenewUrl { get; set; }
    }

    public class CycleSettingsViewModel
    {
        public CycleSettingsViewModel()
        {
            CycleFrequencies = new List<SelectListItem>();
        }
        public Guid OrganizationId { get; set; }
        public string StartDate { get; set; }
        public IList<SelectListItem> CycleFrequencies { get; set; }
        public int Duration { get; set; }
        public bool IsUpdate { get; set; }
    }

    public class PeriodSettingsViewModel
    {
        public bool IsEdit { get; set; }
        public int CycleDuration { get; set; }
        public int PeriodFrequency { get; set; }
        public int PeriodDuration { get; set; }

        public int MinPeriods { get; set; }
        public int MaxPeriods { get; set; }
        public int MinDays { get; set; }
        public int MaxDays { get; set; }
    }

    public class AppraisalSettingsPreviewViewModel
    {
        public AppraisalSettingsPreviewViewModel()
        {
            Periods = new List<PeriodsPreview>();
        }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public IList<PeriodsPreview> Periods { get; set; }
        public string PostDataUrl { get; set; }
        public bool IsRenew { get; set; }
    }

    public class PeriodsPreview
    {
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
    }

    public class CycleViewModel
    {
        public string OrganizationName { get; set; }
    }
}