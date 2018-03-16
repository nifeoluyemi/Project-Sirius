using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Sirius.Data.Context;
using Sirius.Data.Migrations;
using Sirius.Web.Infrastructure.IoC;
using Sirius.Web.Infrastructure.Ninject;

namespace Sirius.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AutofacConfig.Initialize(GlobalConfiguration.Configuration);
            AutofacConfiguration.RegisterAutoFac();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngineInit();

            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }

        void ViewEngineInit()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }

        //protected void Session_Start(Object sender, EventArgs e)
        //{
        //    if(Request.IsAuthenticated)
        //    {

        //    }
        //}

        //protected void Session_End(Object sender, EventArgs e)
        //{

        //}

        private void Application_Error(object sender, EventArgs e)
        {

        }
    }
}
