namespace EDU.Core.DTOs.UserDTOs
{
    public class MenuItemDto : BaseDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconPath { get; set; }
        public int RowNumber { get; set; }
    }
}
