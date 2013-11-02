using System;
using System.Collections.Generic;
using BLToolkit.DataAccess;
using Umbrella.BL.Database;
using Umbrella.BL.Entity;

namespace Umbrella.BL.Services
{
    public sealed class OperationService
    {
        private readonly ISessionFactory sessionFactory;

        public OperationService(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        
        public IEnumerable<Operation> GetTaken()
        {
            using (var session = sessionFactory.OpenSession())
            {
                var accessor = DataAccessor.CreateInstance<OperationAccessor>(session);

                return accessor.GetListOfTaken();
            }
        }

        public void DoTake(User user)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var acccessor = DataAccessor.CreateInstance<OperationAccessor>(session);

                acccessor.Insert(
                    user.Id, 
                    DateTime.Now,
                    null);

                transaction.CommitTransaction();
            }
        }
    }
}
