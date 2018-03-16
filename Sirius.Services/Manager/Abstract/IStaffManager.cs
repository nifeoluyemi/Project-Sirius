using Sirius.Data.BusinessObject;
using Sirius.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.Manager.Abstract
{
    public interface IStaffManager : IBaseManager
    {

        #region Get All Method

        IQueryable<PrivilegeRequestBO> PrivilegeRequests(Expression<Func<PrivilegeRequestBO, bool>> predicate);


        #endregion


        #region Get Single Methods

        PrivilegeRequestBO GetPrivilegeRequestById(Guid privilegeRequestId);
        StaffDetailBO GetStaffDetailByEmail(string email);

        #endregion


        #region Add Entities

        void Add(PrivilegeRequestBO privilegeRequest);
        void Add(UserAccountLoginBO userAccountLogin);
        void Add(UserProfileBO userProfile);
        void Add(StaffDetailBO staffDetail);

        #endregion


        #region Update Entities

        void Update(PrivilegeRequestBO privilegeRequest);
        void Update(UserAccountLoginBO userAccountLogin);
        void Update(UserProfileBO userProfile);

        #endregion


        #region Delete Entities

        void Delete(PrivilegeRequestBO privilegeRequest, bool purge = false);
        void Delete(UserAccountLoginBO userAccountLogin, bool purge = false);
        void Delete(UserProfileBO userProfile, bool purge = false);

        #endregion


        #region Other Methods



        #endregion

    }
}
