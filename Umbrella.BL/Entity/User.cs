using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Umbrella.BL.Entity
{
    public sealed class User
    {
        [MapField("User_Id"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }
        public string Login { get; set; }
        [MapField("Last_Name")]
        public string LastName { get; set; }
        [MapIgnore]
        public bool HasPin { get; set; }
    }
}
