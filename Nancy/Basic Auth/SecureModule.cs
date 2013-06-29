using Nancy;
using Nancy.Security;

namespace BasicAuth
{
    public class SecureModule : NancyModule
	{
		public SecureModule(): base("/api/values")
		{
            this.RequiresAuthentication();

			Get["/"] = x => new[] { "value1", "value2" };

            Get["/{id}"] = x => "value";
		}
	}
}