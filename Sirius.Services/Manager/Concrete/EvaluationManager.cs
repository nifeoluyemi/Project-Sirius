using Sirius.Data.BusinessObject;
using Sirius.Data.Repository;
using Sirius.Services.Manager.Abstract;
using Sirius.Services.Manager.StaticManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Sirius.Entity.Enums;
using Sirius.Data.UnitofWork.Abstract;
using System.Linq.Expressions;

namespace Sirius.Services.Manager.Concrete
{
    public class EvaluationManager : BaseManager, IEvaluationManager
    {
        public EvaluationManager(IDbFactory _db, IUnitofWork _unitofWork)
            : base(_db, _unitofWork)
        {

        }


        #region Get All Method
        
        public IQueryable<UserTaskExpectationBO> UserTaskExpectations(Expression<Func<UserTaskExpectationBO, bool>> predicate)
        {
            return db.userTaskExpectationRepository.FindBy(predicate);
        }

        public IQueryable<UserTaskBO> UserTasks(Expression<Func<UserTaskBO, bool>> predicate)
        {
            return db.userTaskRepository.FindBy(predicate);
        }

        public IQueryable<UserTaskEvaluationBO> UserTaskEvaluations(Expression<Func<UserTaskEvaluationBO, bool>> predicate)
        {
            return db.userTaskEvaluationRepository.FindBy(predicate);
        }

        public IQueryable<UserTaskCommentBO> UserTaskComments(Expression<Func<UserTaskCommentBO, bool>> predicate)
        {
            return db.userTaskCommentRepository.FindBy(predicate);
        }

        #endregion


        #region Get Single Methods

      
        public UserTaskBO GetUserTaskById(Guid userTaskId)
        {
            return db.userTaskRepository.FirstOrDefault(u => u.Id == userTaskId);
        }

        public UserTaskEvaluationBO GetUserTaskEvaluationById(Guid userTaskEvaluationId)
        {
            return db.userTaskEvaluationRepository.FirstOrDefault(u => u.Id == userTaskEvaluationId);
        }

        public UserTaskCommentBO GetUserTaskCommentById(Guid userTaskCommentId)
        {
            return db.userTaskCommentRepository.FirstOrDefault(u => u.Id == userTaskCommentId);
        }

        #endregion


        #region Add Entities

       
        public virtual void Add(UserTaskExpectationBO taskExpectation)
        {
            if (taskExpectation == null)
            {
                throw new ArgumentNullException("taskExpectation", "Task Expectation is null");
            }
            else
            {
                db.userTaskExpectationRepository.Add(taskExpectation);
                unitofWork.Commit();
            }
        }

        public virtual void Add(UserTaskBO userTask)
        {
            if (userTask == null)
            {
                throw new ArgumentNullException("userTask", "User Task is null");
            }
            else
            {
                db.userTaskRepository.Add(userTask);
                unitofWork.Commit();
            }
        }

        public virtual void Add(UserTaskEvaluationBO userTaskEvaluation)
        {
            if (userTaskEvaluation == null)
            {
                throw new ArgumentNullException("userTaskEvaluation", "User Task Evaluation is null");
            }
            else
            {
                db.userTaskEvaluationRepository.Add(userTaskEvaluation);
                unitofWork.Commit();
            }
        }

        public virtual void Add(UserTaskCommentBO userTaskComment)
        {
            if (userTaskComment == null)
            {
                throw new ArgumentNullException("userTaskComment", "User Task Comment is null");
            }
            else
            {
                db.userTaskCommentRepository.Add(userTaskComment);
                unitofWork.Commit();
            }
        }
        
        #endregion


        #region Update Entities


        
        public virtual void Update(UserTaskExpectationBO taskExpectation)
        {
            if (taskExpectation == null)
            {
                throw new ArgumentNullException("taskExpectation", "Task Expectation is null");
            }
            else
            {
                db.userTaskExpectationRepository.Edit(taskExpectation);
                unitofWork.Commit();
            }
        }

        public virtual void Update(UserTaskBO userTask)
        {
            if (userTask == null)
            {
                throw new ArgumentNullException("userTask", "User Task is null");
            }
            else
            {
                db.userTaskRepository.Edit(userTask);
                unitofWork.Commit();
            }
        }

        public virtual void Update(UserTaskEvaluationBO userTaskEvaluation)
        {
            if (userTaskEvaluation == null)
            {
                throw new ArgumentNullException("userTaskEvaluation", "User Task Evaluation is null");
            }
            else
            {
                db.userTaskEvaluationRepository.Edit(userTaskEvaluation);
                unitofWork.Commit();
            }
        }

        public virtual void Update(UserTaskCommentBO userTaskComment)
        {
            if (userTaskComment == null)
            {
                throw new ArgumentNullException("userTaskComment", "User Task Comment is null");
            }
            else
            {
                db.userTaskCommentRepository.Edit(userTaskComment);
                unitofWork.Commit();
            }
        }


        #endregion


        #region Delete Entities

        
        public virtual void Delete(UserTaskExpectationBO taskExpectation, bool purge = false)
        {
            if (purge)
            {
                db.userTaskExpectationRepository.Delete(taskExpectation);
                unitofWork.Commit();
            }
            else
            {
                taskExpectation.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(taskExpectation);
            }
        }
        

        public virtual void Delete(UserTaskBO userTask, bool purge = false)
        {
            if (purge)
            {
                db.userTaskRepository.Delete(userTask);
                unitofWork.Commit();
            }
            else
            {
                userTask.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(userTask);
            }
        }

        public virtual void Delete(UserTaskEvaluationBO userTaskEvaluation, bool purge = false)
        {
            if (purge)
            {
                db.userTaskEvaluationRepository.Delete(userTaskEvaluation);
                unitofWork.Commit();
            }
            else
            {
                userTaskEvaluation.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(userTaskEvaluation);
            }
        }

        public virtual void Delete(UserTaskCommentBO userTaskComment, bool purge = false)
        {
            if (purge)
            {
                db.userTaskCommentRepository.Delete(userTaskComment);
                unitofWork.Commit();
            }
            else
            {
                userTaskComment.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(userTaskComment);
            }
        }

        #endregion


        #region Editing Methods

        


        #endregion


        #region Other Methods


        #endregion


        #region Task Methods


        public IEnumerable<UserTaskBO> GetUserTasks(string userId)
        {
            return db.userTaskRepository.FindBy(u => u.UserId == userId && u.Audit.RecordState == RecordStateType.Active);
        }

       
        #endregion


    }
}
