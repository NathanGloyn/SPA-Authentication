using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi_BasicAuth_Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!SkipAuthorisation(actionContext))
            {
                var identity = ParseAuthorizationHeader(actionContext);
                if (identity == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }


                if (!OnAuthorizeUser(identity.Name, identity.Password, actionContext))
                {
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return;
                }

                var principal = new GenericPrincipal(identity, null);

                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                base.OnAuthorization(actionContext);
            }
        }

        protected virtual bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private bool SkipAuthorisation(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any<AllowAnonymousAttribute>();
        }

        protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string encodedToken = null;
            var authorizationHeader = actionContext.Request.Headers.Authorization;
            if (authorizationHeader != null && authorizationHeader.Scheme == "Basic")
            {
                encodedToken = authorizationHeader.Parameter;
            }

            if (string.IsNullOrEmpty(encodedToken))
            {
                return null;
            }

            encodedToken = Encoding.Default.GetString(Convert.FromBase64String(encodedToken));

            var parameters = encodedToken.Split(':');
            if (parameters.Length < 2)
            {
                return null;
            }

            return new BasicAuthenticationIdentity(parameters[0], parameters[1]);
        }
    }
}