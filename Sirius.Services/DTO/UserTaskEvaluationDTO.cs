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
    public class UserTaskEvaluationDTO
    {
        public Guid UserTaskEvaluationId { get; set; }
        public string EvaluatorId { get; set; }
        public string EvaluatorName { get; set; }
        public double Rating { get; set; }
        public string Score { get; set; }
        public string RelativeDateTime { get; set; }
        public DateTime Date { get; set; }


        public static UserTaskEvaluationDTO Map(UserTaskEvaluationBO userTaskEvaluation, IZeus zeus)
        {
            UserTaskEvaluationDTO self = new UserTaskEvaluationDTO
            {
                UserTaskEvaluationId = userTaskEvaluation.Id,
                EvaluatorId = userTaskEvaluation.EvaluatorId,
                Rating = userTaskEvaluation.Rating,
                Score = userTaskEvaluation.Rating  + " / " + userTaskEvaluation.MaximumRating,
                Date = userTaskEvaluation.RatingDate,
                RelativeDateTime = userTaskEvaluation.RatingDate.ToRelativeDate(),
            };
            self.EvaluatorName = userTaskEvaluation.Evaluator == null ? "" : userTaskEvaluation.Evaluator.FirstName + " " + userTaskEvaluation.Evaluator.LastName;
            return self;
        }


        public static IEnumerable<UserTaskEvaluationDTO> Map(IEnumerable<UserTaskEvaluationBO> userTaskEvaluations, IZeus zeus)
        {
            List<UserTaskEvaluationDTO> selfs = new List<UserTaskEvaluationDTO>();
            foreach (UserTaskEvaluationBO userTaskEvaluation in userTaskEvaluations)
            {
                UserTaskEvaluationDTO self = Map(userTaskEvaluation, zeus);
                selfs.Add(self);
            }
            return selfs;
        }

        public static UserTaskEvaluationDTO Map(UserTaskEvaluationBO userTaskEvaluation, string currentUserId, IZeus zeus)
        {
            UserTaskEvaluationDTO self = new UserTaskEvaluationDTO
            {
                UserTaskEvaluationId = userTaskEvaluation.Id,
                EvaluatorId = userTaskEvaluation.EvaluatorId,
                Rating = userTaskEvaluation.Rating,
                Score = userTaskEvaluation.Rating + " / " + userTaskEvaluation.MaximumRating,
                Date = userTaskEvaluation.RatingDate,
                RelativeDateTime = userTaskEvaluation.RatingDate.ToRelativeDate(),
            };
            if (userTaskEvaluation.Evaluator != null)
                self.EvaluatorName = userTaskEvaluation.EvaluatorId == currentUserId ? "You" : userTaskEvaluation.Evaluator.FirstName + " " + userTaskEvaluation.Evaluator.LastName;

            return self;
        }

        public static IEnumerable<UserTaskEvaluationDTO> Map(IEnumerable<UserTaskEvaluationBO> userTaskEvaluations, string currentUserId, IZeus zeus)
        {
            List<UserTaskEvaluationDTO> selfs = new List<UserTaskEvaluationDTO>();
            foreach (UserTaskEvaluationBO userTaskEvaluation in userTaskEvaluations)
            {
                UserTaskEvaluationDTO self = Map(userTaskEvaluation, currentUserId, zeus);
                selfs.Add(self);
            }
            return selfs;
        }
    }
}
