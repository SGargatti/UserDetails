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
           public class UserAddressRepository : BaseRepository, IUserAddressRepository
        {
            public UserAddressRepository(AppDbContext context) : base(context)
            {
            }

        public async Task AddAsync(UserAddressDetail userAddress)
        {
            await _context.UserAddressDetails.AddAsync(userAddress);
        }

        public async Task<IEnumerable<UserAddressDetail>> ListAsync()
            {
                return await _context.UserAddressDetails.ToListAsync();
            }
        }
    }

