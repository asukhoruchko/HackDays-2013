using System;
using System.Collections.Generic;
using System.Linq;
using BLToolkit.DataAccess;
using Umbrella.BL.Entity;

namespace Umbrella.BL.Database
{
    public abstract class OperationAccessor 
        : DataAccessor<Operation>
    {
        //TODO: should be rewrited to use object instead of parameters
        [SprocName("p_add_operation")]
        public abstract void Add(
            [ParamName("User_Id")] int userId, 
            [ParamName("Date_Taken")] DateTime dateTaken,
            [ParamName("count")] int count);

        [SprocName("p_complete_operation")]
        public abstract void Complete(
            [ParamName("User_Id")] int userId,
            [ParamName("Date_Returned")] DateTime dateTaken,
            [ParamName("count")] int count);

        public List<Operation> GetListOfTaken()
        {
            var operations = DbManager.GetTable<Operation>();
            var users = DbManager.GetTable<User>();

            var query =
                from o in operations
                join u in users on o.UserId equals u.Id
                where o.Returned == null
                select new Operation
                    {
                        Id = o.Id,
                        Taken = o.Taken,
                        User = u
                    };

            return query.ToList();
        }
    }
}
