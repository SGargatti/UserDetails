using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Resources
{
    public class UserDetailResource
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int UserAddressId { get; set; }
        public UserDetailAddressResource UserAddress { get; set; }
    }
}
