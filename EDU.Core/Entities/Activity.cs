namespace EDU.Core.Entities
{
    public class Activity : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
