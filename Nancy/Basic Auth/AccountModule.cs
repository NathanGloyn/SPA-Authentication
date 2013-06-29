using Nancy;

namespace BasicAuth
{
    public class AccountModule : NancyModule
    {
        public AccountModule()
            : base("/api/account")
        {
            Get["/"] = x => HttpStatusCode.OK;
        }
    }
}