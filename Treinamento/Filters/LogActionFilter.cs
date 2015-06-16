using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace Treinamento.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private static void Log(RouteData routeData, [CallerMemberName]string methodName = "")
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller: {1} action: {2}", methodName, controllerName, actionName);

            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}