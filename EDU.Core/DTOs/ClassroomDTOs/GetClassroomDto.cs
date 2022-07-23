using EDU.Core.DTOs.EducationDTOs;

namespace EDU.Core.DTOs.ClassroomDTOs
{
    public class GetClassroomDto : BaseDto
    {
        public string Name { get; set; }
        public int EducationId { get; set; }
        public GetEducationDto Education { get; set; }
    }
}
