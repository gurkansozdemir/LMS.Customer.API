using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs.EducationDTOs
{
    public class SetEducationDto
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public bool IsCertificate { get; set; }
    }
}
