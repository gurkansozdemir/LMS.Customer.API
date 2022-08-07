using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class Inspection : BaseEntity
    {
        public int StudentId { get; set; }
        public User Student { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
        public bool IsCome { get; set; }
    }
}
