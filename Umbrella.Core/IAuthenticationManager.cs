namespace Umbrella.Core
{
    public interface IAuthenticationManager
    {
        bool IsVIAcodeUser(string userName, string password);
    }
}