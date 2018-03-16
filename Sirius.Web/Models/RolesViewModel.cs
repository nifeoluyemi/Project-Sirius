using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirius.Web.Models
{
    public class RolesViewModel
    {
        public bool IsStaff { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsHOD { get; set; }
        public bool IsPMAdmin { get; set; }
        public bool IsITAdmin { get; set; }
        public bool IsMachine { get; set; }
        public bool IsGlobalAdmin { get; set; }
    }
}