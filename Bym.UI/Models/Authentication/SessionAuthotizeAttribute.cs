using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Bym.UI.Models.Authentication
{
    public class SessionAuthotizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session.Count > 0;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Login" },
                                       { "controller", "Usuario" }
                                   });
        }
    }
}