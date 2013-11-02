using System.Data.SqlClient;
using BLToolkit.Data;
using Umbrella.BL.Database;

namespace Umbrella.BL.Test.TestUtils
{
    class TestSessionFactory : ISessionFactory
    {
        public DbManager OpenSession()
        {
            return new DbManager(new SqlConnection("Server=SMIKHALEV.VIACODE.COM;database=UmbrellaDB;User ID=sa;Password=sa2006!"));
        }
    }
}
