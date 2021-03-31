using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Resources
{
    public class UserDetailAddressResource
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int houseNumber { get; set; }
        public string postCode { get; set; }

    }
}
