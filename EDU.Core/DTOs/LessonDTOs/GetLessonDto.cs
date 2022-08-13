using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs.LessonDTOs
{
    public class GetLessonDto : BaseDto
    {
        public string Name { get; set; }
        public int EducationId { get; set; }
    }
}
