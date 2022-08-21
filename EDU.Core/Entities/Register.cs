using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Core.Entities
{
    public class Register: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public int AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
