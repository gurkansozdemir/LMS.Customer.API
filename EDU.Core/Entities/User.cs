namespace EDU.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

    }
}
