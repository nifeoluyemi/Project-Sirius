using Sirius.Data.BusinessObject;
using Sirius.Data.Repository;
using Sirius.Services.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNet.Identity;
using Sirius.Services.Manager.StaticManagers;
using Sirius.Entity.Enums;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Services.Wrappers;
using System.Linq.Expressions;

namespace Sirius.Services.Manager.Concrete
{
    public class StaffManager : BaseManager, IStaffManager
    {
        public StaffManager(IDbFactory _db, IUnitofWork _unitofWork)
            : base(_db, _unitofWork)
        {

        }


        #region Get All Method


        public IQueryable<PrivilegeRequestBO> PrivilegeRequests(Expression<Func<PrivilegeRequestBO, bool>> predicate)
        {
            return db.privilegeRequestRepository.FindBy(predicate);
        }


        #endregion


        #region Get Single Methods

        public PrivilegeRequestBO GetPrivilegeRequestById(Guid privilegeRequestId)
        {
            return db.privilegeRequestRepository.FirstOrDefault(p => p.Id == privilegeRequestId);
        }

        public StaffDetailBO GetStaffDetailByEmail(string email)
        {
            return db.staffDetailRepository.FirstOrDefault(s => s.Email == email);
        }
        #endregion


        #region Add Entities

        public virtual void Add(PrivilegeRequestBO privilegeRequest)
        {
            if (privilegeRequest == null)
            {
                throw new ArgumentNullException("reviewNomination", "Privilege Request is null");
            }
            else
            {
                db.privilegeRequestRepository.Add(privilegeRequest);
                unitofWork.Commit();
            }
        }

        public virtual void Add(UserAccountLoginBO userAccountLogin)
        {
            if (userAccountLogin == null)
            {
                throw new ArgumentNullException("userAccountLogin", "User Account Login is null");
            }
            else
            {
                db.userAccountLoginRepository.Add(userAccountLogin);
                unitofWork.Commit();
            }
        }

        public virtual void Add(UserProfileBO userProfile)
        {
            if (userProfile == null)
            {
                throw new ArgumentNullException("userProfile", "User Profile is null");
            }
            else
            {
                db.userProfileRepository.Add(userProfile);
                unitofWork.Commit();
            }
        }

        public virtual void Add(StaffDetailBO staffDetail)
        {
            if (staffDetail == null)
            {
                throw new ArgumentNullException("staffdetail", "Staff Detail is Null");
            }
            else
	        {
                db.staffDetailRepository.Add(staffDetail);
                unitofWork.Commit();
	        }
        }

        #endregion


        #region Update Entities

        public virtual void Update(PrivilegeRequestBO privilegeRequest)
        {
            if (privilegeRequest == null)
            {
                throw new ArgumentNullException("privilegeRequest", "Privilege Request is null");
            }
            else
            {
                db.privilegeRequestRepository.Edit(privilegeRequest);
                unitofWork.Commit();
            }
        }

        public virtual void Update(UserAccountLoginBO userAccountLogin)
        {
            if (userAccountLogin == null)
            {
                throw new ArgumentNullException("userAccountLogin", "User Account Login is null");
            }
            else
            {
                db.userAccountLoginRepository.Edit(userAccountLogin);
                unitofWork.Commit();
            }
        }

        public virtual void Update(UserProfileBO userProfile)
        {
            if (userProfile == null)
            {
                throw new ArgumentNullException("userProfile", "User Profile is null");
            }
            else
            {
                db.userProfileRepository.Edit(userProfile);
                unitofWork.Commit();
            }
        }


        #endregion


        #region Delete Entities

        public virtual void Delete(PrivilegeRequestBO privilegeRequest, bool purge = false)
        {
            if (purge)
            {
                db.privilegeRequestRepository.Delete(privilegeRequest);
                unitofWork.Commit();
            }
            else
            {
                privilegeRequest.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(privilegeRequest);
            }
        }

        public virtual void Delete(UserAccountLoginBO userAccountLogin, bool purge = false)
        {
            if (purge)
            {
                db.userAccountLoginRepository.Delete(userAccountLogin);
                unitofWork.Commit();
            }
            else
            {
                userAccountLogin.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(userAccountLogin);
            }
        }

        public virtual void Delete(UserProfileBO userProfile, bool purge = false)
        {
            if (purge)
            {
                db.userProfileRepository.Delete(userProfile);
                unitofWork.Commit();
            }
            else
            {
                userProfile.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(userProfile);
            }
        }

        #endregion


        
    }
}
