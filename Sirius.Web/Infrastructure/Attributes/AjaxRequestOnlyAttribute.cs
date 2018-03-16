using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sirius.Web.Infrastructure.Attributes
{
    public class AjaxRequestOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 404;
                filterContext.Result = new HttpNotFoundResult();
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}