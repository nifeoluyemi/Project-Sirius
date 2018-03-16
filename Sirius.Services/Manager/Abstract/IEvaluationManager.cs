using Sirius.Data.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.Abstract
{
    public interface IEvaluationManager : IBaseManager
    {

        #region Get All Method

        IQueryable<UserTaskExpectationBO> UserTaskExpectations(Expression<Func<UserTaskExpectationBO, bool>> predicate);
        IQueryable<UserTaskBO> UserTasks(Expression<Func<UserTaskBO, bool>> predicate);
        IQueryable<UserTaskEvaluationBO> UserTaskEvaluations(Expression<Func<UserTaskEvaluationBO, bool>> predicate);
        IQueryable<UserTaskCommentBO> UserTaskComments(Expression<Func<UserTaskCommentBO, bool>> predicate);


        #endregion


        #region Get Single Method

        UserTaskBO GetUserTaskById(Guid userTaskId);
        UserTaskEvaluationBO GetUserTaskEvaluationById(Guid userTaskEvaluationId);
        UserTaskCommentBO GetUserTaskCommentById(Guid userTaskCommentId);

        #endregion


        #region Add Entities

        void Add(UserTaskExpectationBO taskExpectation);
        void Add(UserTaskBO userTask);
        void Add(UserTaskEvaluationBO userTaskEvaluation);
        void Add(UserTaskCommentBO userTaskComment);


        #endregion


        #region Update Entities

        void Update(UserTaskExpectationBO taskExpectation);
        void Update(UserTaskBO userTask);
        void Update(UserTaskEvaluationBO userTaskEvaluation);
        void Update(UserTaskCommentBO userTaskComment);

        #endregion


        #region Delete Entities

        void Delete(UserTaskExpectationBO taskExpectation, bool purge = false);
        void Delete(UserTaskBO userTask, bool purge = false);
        void Delete(UserTaskEvaluationBO userTaskEvaluation, bool purge = false);
        void Delete(UserTaskCommentBO userTaskComment, bool purge = false);

        #endregion


        #region Editing Methods




        #endregion


        #region Other Methods


        #endregion


        #region Task Methods

        IEnumerable<UserTaskBO> GetUserTasks(string userId);


        #endregion


        #region boolean Methods


        #endregion

    }
}
