using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sirius.Services.DTO;

namespace Sirius.Web.Models
{
    public class TaskViewModel
    {
        public bool IsValidAppraisalCycle { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSupervisor { get; set; }
        public bool CanAppraise { get; set; }
        public bool CanCreateTask { get; set; }
        public string UserFirstname { get; set; }
        public IEnumerable<UserTaskDTO> Tasks { get; set; }
    }


    public class TaskDetailViewModel
    {
        public UserTaskDTO Task { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSupervisor { get; set; }
        public bool CanAppraise { get; set; }
    }


    

    
}