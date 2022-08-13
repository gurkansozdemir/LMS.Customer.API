using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs.ClassroomDTOs
{
    public class ClassroomDetailDto
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public string EducationName { get; set; }
        public int StudentCount { get; set; }
        public int ActivityCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EducationId { get; set; }
    }
}
