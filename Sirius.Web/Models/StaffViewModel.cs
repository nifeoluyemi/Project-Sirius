using Sirius.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirius.Web.Models
{
    public class StaffViewModel
    {
    }

    public class DashboardViewModel
    {
        public string UserId { get; set; }
        public Guid DepartmentId { get; set; }
        public string SupervisorId { get; set; }
    }

}