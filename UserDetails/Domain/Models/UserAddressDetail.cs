using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Domain.Models
{
    public class UserAddressDetail
    {
      //  [ForeignKey("User")]
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int houseNumber { get; set; }
        public string postCode { get; set; }
        //public User userDetail { get; set; };
        //public int UserId { get; set; }
       public ICollection<User> Users { get; set; }
    }
}
