using System;

namespace Umbrella.BL.Entity
{
    public sealed class Operation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime? Taken { get; set; }
        public DateTime? Returned { get; set; }
    }
}
