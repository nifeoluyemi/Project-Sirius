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
using Sirius.Data.UnitofWork.Abstract;

namespace Sirius.Services.Manager.Concrete
{
    public class BaseManager : IBaseManager
    {
        //protected static DataSource db = new DataSource();

        public IUnitofWork unitofWork;
        public IDbFactory db;

        public BaseManager(IDbFactory _db, IUnitofWork _unitofWork)
        {
            db = _db;
            unitofWork = _unitofWork;
        }

        
        public bool IsOrganizationActive(Guid orgId)
        {
            OrganizationBO org = db.organizationRepository.FindBy(o => o.Id == orgId && o.Audit.RecordState == Entity.Enums.RecordStateType.Active).FirstOrDefault();
            return (org != null && org.Status == Entity.Enums.Status.ACTIVE) ? true : false;
        }

        #region Add Entities

        
       
        #endregion 


        #region Update Entities
        

        #endregion


        #region Delete Entities


        #endregion


        #region Get Entities




        #endregion
    }
}
