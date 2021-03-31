using System;

using System.ComponentModel.DataAnnotations;

namespace UserDetails.Resources
{
    public class SaveUserDetailResource
    {
        [Required]
        [MaxLength(30)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string surName { get; set; }
        
       
        public DateTime dateOfBirth { get; set; }
        public UserDetailAddressResource UserAddress { get; set; }
    }
}
