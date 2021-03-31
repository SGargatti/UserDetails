using System;
using System.Collections.Generic;


namespace UserDetails.Domain.Models
{
    public class User
    {
        public int id { get; set; }
        
        public string firstName { get; set; }
        public string surName { get; set; }
        public DateTime dateOfBirth { get; set; }
        // public int UserAddressDetailId { get; set; }
        public int UserAddressId { get; set; }
        
        public  UserAddressDetail userAddressDetail { get; set; }
       
    }
}
