using LolWebAPI.Models;
using LolWebApiRest.Data;
using System.Text.RegularExpressions;

namespace LolWebApiRest.Repository
{
    public class DuoRepository : IDuoRepository
    {
        private readonly DuoDbContext _context;

        public DuoRepository(DuoDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);

        }

    }
}
