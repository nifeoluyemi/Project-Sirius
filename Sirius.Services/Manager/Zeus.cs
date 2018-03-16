using Sirius.Data.Repository;
using Sirius.Data.UnitofWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Services.Manager.Abstract;
using Sirius.Services.Manager.Concrete;

namespace Sirius.Services.Manager
{
    public class Zeus : IZeus
    {
        IDbFactory db;
        IUnitofWork unitofWork;

        public Zeus(IDbFactory _db, IUnitofWork _unitofWork)
        {
            db = _db;
            unitofWork = _unitofWork;
        }

        private IEvaluationManager _evaluationManager;
        private IMessageManager _messageManager;
        private INotificationManager _notificationManager;
        private IOrganizationManager _organizationManager;
        private IStaffManager _staffManager;

        public IEvaluationManager evaluationManager
        {
            get
            {
                return _evaluationManager ?? (_evaluationManager = new EvaluationManager(db, unitofWork));
            }
        }

        public IMessageManager messageManager
        {
            get
            {
                return _messageManager ?? (_messageManager = new MessageManager(db, unitofWork));
            }
        }

        public INotificationManager notificationManager
        {
            get
            {
                return _notificationManager ?? (_notificationManager = new NotificationManager(db, unitofWork));
            }
        }

        public IOrganizationManager organizationManager
        {
            get
            {
                return _organizationManager ?? (_organizationManager = new OrganizationManager(db, unitofWork));
            }
        }

        public IStaffManager staffManager
        {
            get
            {
                return _staffManager ?? (_staffManager = new StaffManager(db, unitofWork));
            }
        }
    }
}
