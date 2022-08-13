using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}
