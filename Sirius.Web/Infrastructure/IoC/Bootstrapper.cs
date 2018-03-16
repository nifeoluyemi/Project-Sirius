using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sirius.Web.Infrastructure.IoC
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}