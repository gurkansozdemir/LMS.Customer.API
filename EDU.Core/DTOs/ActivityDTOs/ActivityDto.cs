namespace EDU.Core.DTOs.ActivityDTOs
{
    public class ActivityDto : BaseDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int ClassroomId { get; set; }
        public int LessonId { get; set; }
    }
}
