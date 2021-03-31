using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;

namespace UserDetails.Domain.Repositories
{
    public interface IUserAddressRepository
    {
        Task<IEnumerable<UserAddressDetail>> ListAsync();
        Task AddAsync(UserAddressDetail userAddress);
    }
}
