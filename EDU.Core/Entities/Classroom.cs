namespace EDU.Core.Entities
{
    public class Classroom : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TeacherOfClassroom> Teachers { get; set; }
        public ICollection<StudentOfClassroom> Students { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
