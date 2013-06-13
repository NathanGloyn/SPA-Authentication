namespace WebApi_BasicAuth_MessageHandler
{
    public static class UserCredentials
    {
        public static bool Validate(string username, string password)
        {
            return (username == password);
        }
    }
}