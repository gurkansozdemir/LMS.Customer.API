using EDU.Core.DTOs.ActivityDTOs;
using EDU.Core.DTOs.UserDTOs;

namespace EDU.Core.DTOs.InpectionDTOs
{
    public class GetInspectionDto : BaseDto
    {
        public int ActivityId { get; set; }
        public int StudentId { get; set; }
        public GetUserDto Student { get; set; }
        public ActivityDto Activity { get; set; }
        public bool IsCome { get; set; }
    }
}
