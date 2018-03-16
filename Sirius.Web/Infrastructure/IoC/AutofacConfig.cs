using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Sirius.Data.Context;
using Sirius.Data.Repository.Abstract;
using Sirius.Data.Repository.Concrete;
using Sirius.Data.UnitofWork.Abstract;
using Sirius.Data.UnitofWork.Concrete;
using Sirius.Services.Manager;
using Sirius.Services.Manager.Abstract;
using Sirius.Services.Manager.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Sirius.Web.Infrastructure.IoC
{
    public class AutofacConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SiriusContext>()
                   .As<DbContext>()
                   .InstancePerRequest();

            builder.RegisterType<UnitofWork>()
                   .As<IUnitofWork>()
                   .InstancePerRequest();

            builder.RegisterType<DbFactory>()
                   .As<IDbFactory>()
                   .InstancePerRequest();

            builder.RegisterGeneric(typeof(BaseRepository<>))
                   .As(typeof(IBaseRepository<>))
                   .InstancePerRequest();

            builder.RegisterType<BaseManager>()
                   .As<IBaseManager>()
                   .InstancePerRequest();

            builder.RegisterType<EvaluationManager>()
                   .As<IEvaluationManager>()
                   .InstancePerRequest();

            builder.RegisterType<MessageManager>()
                   .As<IMessageManager>()
                   .InstancePerRequest();

            builder.RegisterType<NotificationManager>()
                   .As<INotificationManager>()
                   .InstancePerRequest();

            builder.RegisterType<OrganizationManager>()
                   .As<IOrganizationManager>()
                   .InstancePerRequest();

            builder.RegisterType<StaffManager>()
                   .As<IStaffManager>()
                   .InstancePerRequest();

            builder.RegisterType<Zeus>()
                   .As<IZeus>()
                   .InstancePerRequest();

            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            return Container;
        }
    }
}