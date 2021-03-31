using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Services.Communication;

namespace UserDetails.Domain.Services
{
    public interface IUserDetailAddressService
    {
        Task<IEnumerable<UserAddressDetail>> ListAsync();
        Task<SaveUserAddressDetailResponse> SaveAsync(UserAddressDetail userAddress);
    }
}
