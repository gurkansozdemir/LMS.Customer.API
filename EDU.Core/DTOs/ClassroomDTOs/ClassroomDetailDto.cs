namespace EDU.Core.DTOs.ClassroomDTOs
{
    public class ClassroomDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public string EducationName { get; set; }
        public int EducationHour { get; set; }
        public int StudentCount { get; set; }
        public int ActivityCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EducationId { get; set; }
    }
}
