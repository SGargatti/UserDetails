using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Repositories;
using UserDetails.Persistence.Contexts;

namespace UserDetails.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserDetailRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.Include(u=>u.userAddressDetail).ToListAsync();
        }
    }
}
