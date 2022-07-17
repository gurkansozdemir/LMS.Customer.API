using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class Education : BaseEntity
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public bool IsCertificate { get; set; }

    }
}
