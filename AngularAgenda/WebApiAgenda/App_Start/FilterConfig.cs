using System.Web;
using System.Web.Mvc;

namespace WebApiAgenda
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AddCustomHeaderFilter());
        }
    }

    public class AddCustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
           // actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}