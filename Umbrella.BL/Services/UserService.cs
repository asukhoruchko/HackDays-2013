using System;
using BLToolkit.DataAccess;
using Umbrella.BL.Database;
using Umbrella.BL.Entity;
using Umbrella.BL.Exceptions;
using Umbrella.Core;

namespace Umbrella.BL.Services
{
    public sealed class UserService
    {        
        private readonly IAuthenticationManager manager;
        private readonly ISessionFactory sessionFactory;

        public UserService(IAuthenticationManager manager, ISessionFactory sessionFactory)
        {
            this.manager = manager;
            this.sessionFactory = sessionFactory;
        }

        public User Authenticate(string login, string password)
        {
            if (!manager.IsVIAcodeUser(login, password))
            {
                throw new InvalidUserException();
            }

            var result = GetUser(login) ?? Create(login);

            return result;
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        private User Create(string login)
        {
            var user = new User
                {
                    Login = login,
                    LastName = login.Substring(1)
                };
            
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var userAccessor = DataAccessor.CreateInstance<UserAccessor>(session);

                userAccessor.Insert(user);

                transaction.CommitTransaction();

                //TODO: We need this to get and ID. Normally it should be done via Accessor. Some issues occured, skipping now
                user = GetUser(login); 
            }

            return user;
        }

        private User GetUser(string login)
        {
            using (var session = sessionFactory.OpenSession())
            {
                var userAccessor = DataAccessor.CreateInstance<UserAccessor>(session);

                var result = userAccessor.GetByLogin(login);

                return result;
            }
        }
    }
}
