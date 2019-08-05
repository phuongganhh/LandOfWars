using System;
using System.Web.Mvc;

public class Cors : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");

        base.OnActionExecuting(filterContext);
    }
}