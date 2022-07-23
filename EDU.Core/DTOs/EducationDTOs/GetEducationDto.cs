namespace EDU.Core.DTOs.EducationDTOs
{
    public class GetEducationDto : BaseDto
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public bool IsCertificate { get; set; }
    }
}
