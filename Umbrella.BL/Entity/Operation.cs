using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Umbrella.BL.Entity
{
    [TableName("OperationLog")]
    public sealed class Operation
    {
        [MapField("operation_log_id"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }
        [MapField("User_Id")]
        public int? UserId { get; set; }
        [MapField("Date_Taken")]
        public DateTime? Taken { get; set; }
        [MapField("Date_Returned")]
        public DateTime? Returned { get; set; }

        [Association(ThisKey = "UserId", OtherKey = "UserId", CanBeNull = false)]
        public User User { get; set; }
    }
}
