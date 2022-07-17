using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class TeacherOfClassroom
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
