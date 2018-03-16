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
    public interface IOrganizationManager : IBaseManager
    {

        #region Get All Method

        IQueryable<OrganizationBO> Organizations(Expression<Func<OrganizationBO, bool>> predicate);


        #endregion


        #region Get Single Method

       
        OrganizationBO GetOrganizationById(Guid organizationId);
        OrganizationBO GetOrganizationByShortName(string shortname);

        #endregion


        #region Add Entities

        void Add(OrganizationBO organization);

        #endregion


        #region Update Entities

        void Update(OrganizationBO organization);

        #endregion


        #region Delete Entities

        void Delete(OrganizationBO organization, bool purge = false);

        #endregion


        #region Get Entities


        #endregion

        #region Remove


        #endregion


    }
}
