namespace EDU.Core.DTOs.UserDTOs
{
    public class GetUserDto : BaseDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
    }
}
