using System;
using Umbrella.BL.Entity;
using Umbrella.BL.Exceptions;
using Umbrella.Core;

namespace Umbrella.BL.Services
{
    public sealed class UserService
    {
        private readonly AuthenticationManager manager;

        public UserService(AuthenticationManager manager)
        {
            this.manager = manager;
        }

        public User Authentificate(string login, string password)
        {
            if (!manager.IsVIAcodeUser(login, password))
            {
                throw new InvalidUserException();
            }
            

            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        private void Create(User user)
        {
            
        }

        private User GetUser(string login)
        {
            throw new NotImplementedException();
        }
    }
}
