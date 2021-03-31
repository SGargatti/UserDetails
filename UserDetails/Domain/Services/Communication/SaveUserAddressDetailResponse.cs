using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;

namespace UserDetails.Domain.Services.Communication
{
    public class SaveUserAddressDetailResponse :BaseResponse
    {
        public UserAddressDetail UserAddress { get; private set; }
        private SaveUserAddressDetailResponse(bool success, string message, UserAddressDetail userAddress) : base(success, message)
        {
            UserAddress = userAddress;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="userAddress">Saved user.Address</param>
        /// <returns>Response.</returns>
        public SaveUserAddressDetailResponse(UserAddressDetail userAddress) : this(true, string.Empty, userAddress)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveUserAddressDetailResponse(string message) : this(false, message, null)
        { }
    }
}
