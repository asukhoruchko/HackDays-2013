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

        public OperationService(
            ISessionFactory sessionFactory)
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

        public void Update(User user, int change)
        {
            if (change < 0)
            {
                DoTake(user, change * -1);
            }
            else if (change > 0)
            {
                DoReturn(user, change);    
            }
        }

        private void DoTake(User user, int count)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var acccessor = DataAccessor.CreateInstance<OperationAccessor>(session);

                acccessor.Add(
                            user.Id,
                            DateTime.Now,
                            count);
                    
                transaction.CommitTransaction();
            }
        }

        private void DoReturn(User user, int count)
        {
            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var acccessor = DataAccessor.CreateInstance<OperationAccessor>(session);

                acccessor.Complete(
                            user.Id,
                            DateTime.Now,
                            count);

                transaction.CommitTransaction();
            }
        }
    }
}
