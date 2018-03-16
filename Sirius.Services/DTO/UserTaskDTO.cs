using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using Sirius.Services.Manager.StaticManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.DTO
{
    public class UserTaskDTO
    {
        public Guid UserTaskId { get; set; }

        public bool IsActive { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public string AssignedById { get; set; }
        public string AssignedToId { get; set; }

        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }

        public double MaxScore { get; set; }
        
        //Objective and Goal

        public bool HasSupervisorAccepted { get; set; }
        public bool HasUserAccepted { get; set; }

        public IEnumerable<double> UserTaskRatings { get; set; }

        public string DateCreated { get; set; }
        public string BeginDate { get; set; }
        public string Deadline { get; set; }
        public DateTime CreateDate { get; set; }
        public double Percentage { get; set; }
        public string PercentageComplete { get; set; }
        public bool IsAppraised { get; set; }
        public string UserTaskHtmlId { get; set; }
        public string TaskHtmlId { get; set; }

        public static UserTaskDTO Map(UserTaskBO userTask, IZeus zeus)
        {
            UserTaskDTO self = new UserTaskDTO
            {
                UserTaskId = userTask.Id,
                TaskTitle = userTask.Title,
                Description = userTask.Description,
                AssignedToId = userTask.UserId,
                Percentage = DateExtension.PercentageProgressBetweenDates(userTask.BeginDate, userTask.EndDate),
                PercentageComplete = DateExtension.PercentageProgressBetweenDates(userTask.BeginDate, userTask.EndDate).ToString() + "%",
                DateCreated = DateExtension.ConvertDateToShort(userTask.DateCreated),
                Deadline = DateExtension.ConvertDateToShort(userTask.EndDate),
                BeginDate = DateExtension.ConvertDateToShort(userTask.BeginDate),
                CreateDate = userTask.DateCreated,
                UserTaskHtmlId = StringConversion.ConvertGuidToString(userTask.Id),
                TaskHtmlId = StringConversion.ConvertGuidToString(userTask.Id)
            };

            self.AssignedTo = userTask.User == null ? "" : userTask.User.FirstName + " " + userTask.User.LastName;

            //get list of measure/target

            return self;
        }


        public static IEnumerable<UserTaskDTO> Map(IEnumerable<UserTaskBO> userTasks, IZeus zeus)
        {
            List<UserTaskDTO> selfs = new List<UserTaskDTO>();
            foreach (UserTaskBO userTask in userTasks)
            {
                UserTaskDTO self = UserTaskDTO.Map(userTask, zeus);
                selfs.Add(self);
            }
            return selfs.AsEnumerable();
        }

    }


}
