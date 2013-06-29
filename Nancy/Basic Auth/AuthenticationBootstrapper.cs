using Nancy.Authentication.Basic;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy;

namespace BasicAuth
{
    public class AuthenticationBootstrapper : DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
            base.ApplicationStartup(container, pipelines);

            pipelines.EnableBasicAuthentication(new BasicAuthenticationConfiguration(
                container.Resolve<IUserValidator>(),
                "MyRealm"
                ));
		}

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddFile("/index.html", "/Content/index.html"));
        }
	}
}