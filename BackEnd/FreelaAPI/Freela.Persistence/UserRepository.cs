using Freela.Domain.Models;
using Freela.Persistence.Repository;
using FreelaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly FreelaContext _context;

        public UserRepository(FreelaContext context)
        {
            _context = context;
        }
        public async Task<User[]> GetAllFreelaByAreaAsync(string Area)
        {
            IQueryable<User> query = _context.Users.Include(p => p.Company);
            query = query
                .OrderBy(p => p.Id)
                .Where(p => p.Area.ToLower()
                .Contains(Area.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<User[]> GetAllFreelas()
        {
            IQueryable<User> query = _context.Users.Include(p => p.Company);
            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<User> GetFreelaByIdAsync(int Id)
        {
            IQueryable<User> query = _context.Users.Include(p => p.Company);
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
