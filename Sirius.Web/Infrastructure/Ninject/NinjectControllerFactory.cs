using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Data.UnitofWork.Concrete;
using Sirius.Data.Repository.Abstract;
using Sirius.Data.Repository.Concrete;
using Sirius.Services.Manager.Abstract;
using Sirius.Services.Manager.Concrete;
using Sirius.Services.Manager;

namespace Sirius.Web.Infrastructure.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IUnitofWork>().To<UnitofWork>();
            ninjectKernel.Bind<IDbFactory>().To<DbFactory>();

            ninjectKernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            
            ninjectKernel.Bind<IBaseManager>().To<BaseManager>();
            ninjectKernel.Bind<IEvaluationManager>().To<EvaluationManager>();
            ninjectKernel.Bind<IMessageManager>().To<MessageManager>();
            ninjectKernel.Bind<INotificationManager>().To<NotificationManager>();
            ninjectKernel.Bind<IOrganizationManager>().To<OrganizationManager>();
            ninjectKernel.Bind<IStaffManager>().To<StaffManager>();
            ninjectKernel.Bind<IZeus>().To<Zeus>();
        }
    }
}