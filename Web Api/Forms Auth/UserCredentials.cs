namespace WebApi_FormsAuth
{
    public static class UserCredentials
    {
        public static bool Validate(string username, string password)
        {
            return (username == password);
        }
    }
}