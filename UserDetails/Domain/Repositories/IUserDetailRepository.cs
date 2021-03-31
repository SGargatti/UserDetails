using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDetails.Domain.Models;

namespace UserDetails.Domain.Repositories
{
    public interface IUserDetailRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
    }
}
