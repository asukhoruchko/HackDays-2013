using BLToolkit.Data;

namespace Umbrella.BL.Database
{
    public interface ISessionFactory
    {
        DbManager OpenSession();
    }
}