using System.Security.Principal;

namespace WebApi_BasicAuth_MessageHandler
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public BasicAuthenticationIdentity(string name, string password): base(name, "Basic")
        {
            this.Password = password;
        }

        public string Password { get; set; }
    }
}