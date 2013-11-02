using System;
using System.Collections.Generic;
using Umbrella.BL.Entity;

namespace Umbrella.BL.Services
{
    public sealed class OperationService
    {
        public IEnumerable<Operation> GetTaken()
        {
            return new[]
                {
                    new Operation
                        {
                            User = new User
                                {
                                    LastName = "Vasiliev"
                                },
                            Taken = DateTime.Parse("01.01.2001")
                        },
                    new Operation
                        {
                            User = new User
                                {
                                    LastName = "Petrov"
                                },
                            Taken = DateTime.Parse("02.02.2002")
                        },
                };
        }

        public void DoTake(User user)
        {
            throw new NotImplementedException();
        }
    }
}
