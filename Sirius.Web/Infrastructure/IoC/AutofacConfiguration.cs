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
    public class AutofacConfiguration
    {
        public static IContainer RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            AddMvcRegistrations(builder);
            AddRegisterations(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }

        private static void AddMvcRegistrations(ContainerBuilder builder)
        {
            //mvc
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            //web api
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterModule<AutofacWebTypesModule>();


        }

        private static void AddRegisterations(ContainerBuilder builder)
        {
            //builder.RegisterModule(new MyCustomerWebAutoFacModule());
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
        }
    }
}