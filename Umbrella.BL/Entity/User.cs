namespace Umbrella.BL.Entity
{
    public sealed class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string LastName { get; set; }
        public bool HasPin { get; set; }
    }
}
