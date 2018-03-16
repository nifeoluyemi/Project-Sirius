using Sirius.Data.BusinessObject;
using Sirius.Services.DTO;
using Sirius.Services.Manager;
using Sirius.Services.Wrappers;
using Sirius.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Sirius.Entity;
using Sirius.Entity.Enums;
using System.Data.Entity;


namespace Sirius.Web.RESTful
{
    public class UserTaskApiController : BaseApiController
    {
        public UserTaskApiController(IZeus _zeus)
            : base(_zeus)
        {

        }

        

        

        [HttpPost]
        public async Task<IHttpActionResult> AddTask(AddTaskViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Title))
                    return BadRequest("The title field cannot be empty.");

                UserTaskBO userTask = new UserTaskBO
                {
                    Title = model.Title,
                    Description = model.Description,
                    DateCreated = DateTime.UtcNow,
                    UserId = CurrentUserId,
                    DateUserAccepted = DateTime.UtcNow,
                    BeginDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow,
                    Audit = new Entity.Entities.Audit(CurrentUserId)
                };
                zeus.evaluationManager.Add(userTask);
                await AddNotificationAsync(NotificationType.NewTask, CurrentUserId, CurrentUserId, "supervisor/unacceptedtasks");
                return Ok(UserTaskDTO.Map(userTask, zeus));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest("An Error occured while processing your request, please try again");
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteTask(Guid userTaskId)
        {
            try
            {
                UserTaskBO userTask = zeus.evaluationManager.GetUserTaskById(userTaskId);
                zeus.evaluationManager.Delete(userTask);
                
                return Ok("Your Task has been successfully deleted.");
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest("An error ocurred while deleting this task, please try again.");
            }
        }

        public async Task<IHttpActionResult> GetUserTaskInfo(Guid userTaskId)
        {
            try
            {
                UserTaskDTO result = await Task.Run(() => zeus.evaluationManager.UserTasks(u => u.Audit.RecordState == RecordStateType.Active && u.Id == userTaskId)
                    .Include(u => u.User)
                    .Select(u => new UserTaskDTO
                    {
                        UserTaskId = u.Id,
                        AssignedToId = u.UserId,
                        TaskTitle = u.Title,
                        AssignedTo = u.User.FirstName + " " + u.User.LastName,
                        Description = u.Description,
                    }).FirstOrDefault());
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTaskExpectation(Guid userTaskId)
        {
            try
            {
                IEnumerable<UserTaskExpectationDTO> result = await Task.Run(() => zeus.evaluationManager.UserTaskExpectations(u => u.Audit.RecordState == RecordStateType.Active && u.UserTaskId == userTaskId)
                    .Select(u => new UserTaskExpectationDTO
                    {
                        TaskExpectationId = u.Id,
                        Measure = u.Measure,
                        Target = u.Target
                    }));
                return Ok(result);
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> UserTaskComment(Guid userTaskId)
        {
            try
            {
                IEnumerable<UserTaskCommentBO> comments = await Task.Run(() => zeus.evaluationManager.UserTaskComments(u => u.Audit.RecordState == RecordStateType.Active && u.UserTaskId == userTaskId)
                    .Include(u => u.Commenter)
                    .Select(u => new UserTaskCommentWrapper
                    {
                        Id = u.Id,
                        Comment = u.Comment,
                        CommentDate = u.CommentDate,
                        CommenterId = u.CommenterId,
                        Commenter = new UserWrapper { FirstName = u.Commenter.FirstName, LastName = u.Commenter.LastName }
                    }));
                return Ok(UserTaskCommentDTO.Map(comments, CurrentUserId, zeus));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> UserTaskEvaluation(Guid userTaskId)
        {
            try
            {
                IEnumerable<UserTaskEvaluationBO> evaluations = await Task.Run(() => zeus.evaluationManager.UserTaskEvaluations(u => u.Audit.RecordState == RecordStateType.Active && u.UserTaskId == userTaskId)
                    .Include(u => u.Evaluator)
                    .Select(u => new UserTaskEvaluationWrapper
                    {
                        Id = u.Id,
                        Rating = u.Rating,
                        MaximumRating = u.MaximumRating,
                        EvaluatorId = u.EvaluatorId,
                        RatingDate = u.RatingDate,
                        Evaluator = new UserWrapper { FirstName = u.Evaluator.FirstName, LastName = u.Evaluator.LastName }
                    }));

                return Ok(UserTaskEvaluationDTO.Map(evaluations, CurrentUserId, zeus));
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddComment(TaskCommentViewModel model)
        {
            try
            {
                //add task owner to model
                if (string.IsNullOrWhiteSpace(model.CommentBody))
                    return Json(JsonResponse.Error("Please input a comment."));
                UserTaskCommentBO userTaskComment = new UserTaskCommentBO
                {
                    UserTaskId = model.UserTaskId,
                    Comment = model.CommentBody,
                    CommenterId = CurrentUserId,
                    CommentDate = DateTime.UtcNow,
                    Audit = new Entity.Entities.Audit(CurrentUserId)
                };
                zeus.evaluationManager.Add(userTaskComment);
                await AddNotificationAsync(NotificationType.NewTaskComment, CurrentUserId, model.UserId, "task/" + model.UserTaskId);
                return Ok(new UserTaskCommentDTO { UserTaskCommentId = userTaskComment.Id, CommenterId = CurrentUserId, Comment = model.CommentBody, CommenterName = "You", Date = DateTime.UtcNow });
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteComment(Guid commentId)
        {
            try
            {
                UserTaskCommentBO comment = zeus.evaluationManager.GetUserTaskCommentById(commentId);
                zeus.evaluationManager.Delete(comment);
                return Ok();
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }

        [HttpPost]
        public IHttpActionResult DeleteEvaluation(Guid evaluationId)
        {
            try
            {
                UserTaskEvaluationBO evaluation = zeus.evaluationManager.GetUserTaskEvaluationById(evaluationId);
                zeus.evaluationManager.Delete(evaluation);

                return Ok();
            }
            catch (Exception ex)
            {
                LogError(ex, CurrentUserId);
                return BadRequest();
            }
        }
    }
}
