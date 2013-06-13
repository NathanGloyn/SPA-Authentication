namespace WebApi_BasicAuth_Filter
{
    public static class UserCredentials
    {
        public static bool Validate(string username, string password)
        {
            return (username == password);
        }
    }
}