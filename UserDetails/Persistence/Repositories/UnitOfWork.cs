﻿
using System.Threading.Tasks;
using UserDetails.Domain.Repositories;
using UserDetails.Persistence.Contexts;

namespace UserDetails.Persistence.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
