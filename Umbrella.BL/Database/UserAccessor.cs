using BLToolkit.DataAccess;
using Umbrella.BL.Entity;

namespace Umbrella.BL.Database
{
    public abstract class UserAccessor
        : DataAccessor<User>
    {
        [SprocName("p_insert_user")]
        public abstract void Insert(User user);

        [SqlQuery("SELECT * from [dbo].[User] where [login] = @login")]
        public abstract User GetByLogin(string @login);
    }
}
