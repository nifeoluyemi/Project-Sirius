using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sirius.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Organization",
                url: "{organization}/{controller}/{action}/{id}",
                defaults: new { organization = "default", controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Organization_Login",
                url: "signin",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Organization_Register",
                url: "{organization}/register",
                defaults: new { organization = "default", controller = "Account", action = "Register", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Organization_Confirmation",
                url: "confirmation/{userId}/{code}",
                defaults: new { controller = "Account", action = "ConfirmAccount", userId = UrlParameter.Optional, code = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Organization_PasswordReset",
                url: "reset/{email}/{code}",
                defaults: new { controller = "Account", action = "ConfirmAccount", email = UrlParameter.Optional, code = UrlParameter.Optional }
            );
            
        }
    }
}
