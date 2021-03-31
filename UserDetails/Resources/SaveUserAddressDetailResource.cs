using System;

using System.ComponentModel.DataAnnotations;

namespace UserDetails.Resources
{
    public class SaveUserAddressDetailResource
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int houseNumber { get; set; }
        public string postCode { get; set; }
    }
}
