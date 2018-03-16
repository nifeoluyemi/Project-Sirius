using Sirius.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirius.Web.Models
{
    public class UserTaskViewModel
    {
        public bool IsValidAppraisalCycle { get; set; }
        public Guid CurrentAppraisalCycleId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSupervisor { get; set; }
        public bool CanAppraise { get; set; }
        public string AppraisalOpenDate { get; set; }
        public bool CanCreateTask { get; set; }
        public string UserId { get; set; }
        public string UserFirstname { get; set; }
        public IEnumerable<UserTaskDTO> Tasks { get; set; }
        public double MaxScore { get; set; }
    }

    public class UserTaskDetailViewModel
    {
        public Guid UserTaskId { get; set; }

        public string Username { get; set; }
        public UserTaskDTO Task { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSupervisor { get; set; }
        public bool CanAppraise { get; set; }
        public string AppraisalOpenDate { get; set; }
        public IEnumerable<UserTaskExpectationDTO> Expectations { get; set; }
    }

    public class AddTaskViewModel
    {
        public string Title { get; set; }
        public string Expectation { get; set; }
        public string Description { get; set; }
        public double MaxScore { get; set; }
    }

    public class EditTaskViewModel
    {
        public Guid UserTaskId { get; set; }
        public string Title { get; set; }
        public string Expectation { get; set; }
        public string Description { get; set; }
        public double MaxScore { get; set; }
    }

    public class UserTaskEvaluationViewModel
    {
        public UserTaskEvaluationViewModel()
        {
            Ratings = new List<UserTaskEvaluationDTO>();
        }
        public Guid UserTaskId { get; set; }
        public double Rating { get; set; }
        public double MaxScore { get; set; }
        public string TaskTitle { get; set; }
        public string HtmlId { get; set; }
        public IEnumerable<UserTaskExpectationDTO> Expectations { get; set; }
        
        public List<UserTaskEvaluationDTO> Ratings { get; set; }
    }

    public class UserTaskCommentViewModel
    {
        public UserTaskCommentViewModel()
        {
            Comments = new List<UserTaskCommentDTO>();
        }
        public Guid UserTaskId { get; set; }
        public string CurrentUserId { get; set; }
        public string Comment { get; set; }
        public bool CanComment { get; set; }
        public List<UserTaskCommentDTO> Comments { get; set; }
    }

    public class UserTaskAppraisalViewModel
    {
        public Guid UserTaskId { get; set; }
        public Guid? UserTaskAppraisalId { get; set; }
        public Guid PeriodId { get; set; }
        public bool IsEdit { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public double MaxScore { get; set; }
        public string TaskTitle { get; set; }
        public string HtmlId { get; set; }
        public IEnumerable<UserTaskExpectationDTO> Expectations { get; set; }
    }

    public class TaskSummaryViewModel
    {
        public UserTaskDTO UserTask { get; set; }
        public IEnumerable<UserTaskExpectationDTO> Expectations { get; set; }
    }

    public class AngularTaskVM
    {
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class TaskCommentViewModel
    {
        public string CommentBody { get; set; }
        public Guid UserTaskId { get; set; }
        public string UserId { get; set; }
    }

    public class TaskEvaluationViewModel
    {
        public Guid UserTaskId { get; set; }
        public string UserId { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
    }
}