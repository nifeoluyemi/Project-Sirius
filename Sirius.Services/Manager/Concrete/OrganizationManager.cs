using Sirius.Data.BusinessObject;
using Sirius.Data.Repository;
using Sirius.Services.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Sirius.Entity.Enums;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Services.Wrappers;
using System.Data.Entity;

namespace Sirius.Services.Manager.Concrete
{
    public class OrganizationManager : BaseManager, IOrganizationManager
    {
        public OrganizationManager(IDbFactory _db, IUnitofWork _unitofWork)
            : base(_db, _unitofWork)
        {

        }


        #region Get All Method

        public IQueryable<OrganizationBO> Organizations(Expression<Func<OrganizationBO, bool>> predicate)
        {
            return db.organizationRepository.FindBy(predicate);
        }


        #endregion



        #region Get Single Method

        
        //Get an Organization by Id
        public OrganizationBO GetOrganizationById(Guid organizationId)
        {
            return db.organizationRepository.FirstOrDefault(o => o.Id == organizationId);
        }

        //Get an Organization by the organization's shortname
        public OrganizationBO GetOrganizationByShortName(string shortname)
        {
            return db.organizationRepository.FindBy(o => o.ShortName == shortname).FirstOrDefault();
        }

        
        #endregion


        #region Add Entities

       
        public virtual void Add(OrganizationBO organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException("organization", "Organization is null");
            }
            else
            {
                db.organizationRepository.Add(organization);
                unitofWork.Commit();
            }
        }

        #endregion


        #region Update Entities

       
        public virtual void Update(OrganizationBO organization)
        {
            if (organization == null)
            {
                throw new ArgumentNullException("organization", "Organization is null");
            }
            else
            {
                db.organizationRepository.Edit(organization);
                unitofWork.Commit();
            }
        }

        #endregion


        #region Delete Entities

        
        public virtual void Delete(OrganizationBO organization, bool purge = false)
        {
            if (purge)
            {
                db.organizationRepository.Delete(organization);
                unitofWork.Commit();
            }
            else
            {
                organization.Audit.RecordState = Entity.Enums.RecordStateType.InActive;
                Update(organization);
            }
        }


        #endregion


        #region Get Entities

        #endregion


        #region Remove


        #endregion

    }
}
