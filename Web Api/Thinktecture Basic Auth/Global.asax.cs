using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Thinktecture.IdentityModel.Tokens.Http;
using WebApi_SessionToken;

namespace WebApi_BasicAuth_Thinktecture
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureGlobal(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void ConfigureGlobal(HttpConfiguration globalConfig)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            globalConfig.MessageHandlers.Add(new AuthenticationHandler(CreateConfiguration()));
        }

        private AuthenticationConfiguration CreateConfiguration()
        {
            var config = new AuthenticationConfiguration
            {
                EnableSessionToken = true,
                RequireSsl = false,
                SendWwwAuthenticateResponseHeaders = false
            };

            config.AddBasicAuthentication(UserCredentials.Validate);

            return config;
        }
    }
}