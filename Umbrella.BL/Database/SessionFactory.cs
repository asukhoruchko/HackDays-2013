using BLToolkit.Data;

namespace Umbrella.BL.Database
{
    public sealed class SessionFactory : ISessionFactory
    {
        private readonly string connectionName;
        private readonly int queryTimeout;

        public SessionFactory(string connectionName, int queryTimeout)
        {
            this.connectionName = connectionName;
            this.queryTimeout = queryTimeout;
        }

        public DbManager OpenSession()
        {
            var result = new DbManager(connectionName);
            result.Command.CommandTimeout = queryTimeout;

            return result;
        }
    }
}
