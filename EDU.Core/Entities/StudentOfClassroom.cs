using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class StudentOfClassroom
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public DateTime? LeaveDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
