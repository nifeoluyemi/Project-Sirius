using System.Web.Mvc;

namespace Sirius.Web.Areas.thoth
{
    public class thothAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "thoth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "thoth_default",
                "thoth/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}