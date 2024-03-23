using LolWebAPI.Models;
using LolWebApiRest.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LolWebApiRest.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly DuoDbContext _context;

        public AnuncioRepository(DuoDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<Duo[]> GetAllDuos()
        {
            IQueryable<Duo> query = _context.Duos;
            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Duo> GetDuoByIdAsync(int Id)
        {
            IQueryable<Duo> query = _context.Duos;
            query = query.OrderBy(p => p.Id).Where(p => p.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
