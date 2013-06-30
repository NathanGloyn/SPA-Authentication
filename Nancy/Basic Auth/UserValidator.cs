using Nancy.Authentication.Basic;
using Nancy.Security;

namespace BasicAuth
{
    public class UserValidator : IUserValidator
	{
		public IUserIdentity Validate(string username, string password)
		{
		    return new UserIdentity {UserName = username};
		}
	}
}