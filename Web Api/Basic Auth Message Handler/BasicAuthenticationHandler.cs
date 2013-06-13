using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_BasicAuth_MessageHandler
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var credentials = ParseAuthorizationHeader(request);

            if (credentials != null)
            {
                if (UserCredentials.Validate(credentials.Name, credentials.Password))
                {
                    // check the uri, it they called the token uri then since the user
                    // only wants to login we return a 200 to signal valid user
                    if (request.RequestUri.Segments.Last().ToLower() == "token")
                    {
                        return Task.Factory.StartNew(() =>
                        {
                            return new HttpResponseMessage(HttpStatusCode.OK);
                        });
                    }

                    var identity = new BasicAuthenticationIdentity(credentials.Name, credentials.Password);
                    var principal = new GenericPrincipal(identity, null);

                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                }
            }

            return base.SendAsync(request, cancellationToken);
        }


        protected virtual BasicAuthenticationIdentity ParseAuthorizationHeader(HttpRequestMessage request)
        {
            string encodedToken = null;
            var authorizationHeader = request.Headers.Authorization;
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