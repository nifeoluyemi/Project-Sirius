using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.DTO
{
    public class UserTaskExpectationDTO
    {
        public Guid TaskExpectationId { get; set; }
        public Guid TaskId { get; set; }
        public string Measure { get; set; }
        public string Target { get; set; }

        public static UserTaskExpectationDTO Map(UserTaskExpectationBO userTaskExpectation, IZeus zeus)
        {
            UserTaskExpectationDTO self = new UserTaskExpectationDTO
            {
                TaskExpectationId = userTaskExpectation.Id,
                TaskId = userTaskExpectation.UserTaskId,
                Measure = userTaskExpectation.Measure,
                Target = userTaskExpectation.Target
            };
            return self;
        }

        public static IEnumerable<UserTaskExpectationDTO> Map(IEnumerable<UserTaskExpectationBO> userTaskExpectations, IZeus zeus)
        {
            List<UserTaskExpectationDTO> selfs = new List<UserTaskExpectationDTO>();
            foreach(UserTaskExpectationBO taskExpectation in userTaskExpectations)
            {
                UserTaskExpectationDTO self = UserTaskExpectationDTO.Map(taskExpectation, zeus);
                selfs.Add(self);
            }
            return selfs;
        }
    }
}
