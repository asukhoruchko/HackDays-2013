using System.DirectoryServices.AccountManagement;

namespace Umbrella.Core
{
    public class AuthenticationManager : IAuthenticationManager
    {
        public bool IsVIAcodeUser(string userName, string password)
        {
            using (var pc = new PrincipalContext(ContextType.Domain, "VIACODE"))
            {
                return pc.ValidateCredentials(userName, password);
            }
        }
    }
}
