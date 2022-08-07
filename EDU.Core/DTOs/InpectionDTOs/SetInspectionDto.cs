using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.DTOs.InpectionDTOs
{
    public class SetInspectionDto
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int StudentId { get; set; }
        public bool IsCome { get; set; }
    }
}
