using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Umbrella.BL.Entity
{
    public sealed class Operation
    {
        [MapField("Operation_Id"), PrimaryKey, NonUpdatable]
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Taken { get; set; }
        public DateTime? Returned { get; set; }
    }
}
