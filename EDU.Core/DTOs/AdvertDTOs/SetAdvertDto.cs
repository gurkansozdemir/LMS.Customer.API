namespace EDU.Core.DTOs.AdvertDTOs
{
    public class SetAdvertDto
    {
        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int EducationId { get; set; }
    }
}
